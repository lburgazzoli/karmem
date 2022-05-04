package karmem

import (
	"errors"
	"unsafe"
)

var (
	// ErrOutOfMemory happens when alloc is required while using NewFixedWriter.
	ErrOutOfMemory = errors.New("out-of-memory, FixedWriter can't reallocate")
)

func init() {
	if s := unsafe.Sizeof(int(0)); s != 4 && s != 8 {
		panic("karmem only supports 32bits and 64bits")
	}
	if (*(*[2]uint8)(unsafe.Pointer(&([]uint16{1})[0])))[0] == 0 {
		panic("karmem only supports Little-Endian")
	}
}

// Writer holds the encoded, the finished encode can be retrieved by Writer.Bytes()
type Writer struct {
	Memory  []byte
	isFixed bool
}

// NewWriter creates a Writer with the given initial capacity.
func NewWriter(capacity int) *Writer {
	return &Writer{Memory: make([]byte, 0, capacity), isFixed: false}
}

// NewFixedWriter creates a Writer from an existent memory segment/buffer.
// The memory can't be resized.
func NewFixedWriter(mem []byte) *Writer {
	return &Writer{Memory: mem, isFixed: true}
}

// Alloc allocates n bytes inside.
// It returns the offset and may return error if it's not possible to allocate.
func (w *Writer) Alloc(n uint) (uint, error) {
	ptr := uint(len(w.Memory))
	total := ptr + n
	if total > uint(cap(w.Memory)) {
		if w.isFixed {
			return 0, ErrOutOfMemory
		}
		w.Memory = append(w.Memory, make([]byte, total-uint(len(w.Memory)))...)
	} else {
		w.Memory = w.Memory[:total]
	}
	return ptr, nil
}

// WriteAt copies the given data into the Writer memory.
func (w *Writer) WriteAt(offset uint, data []byte) {
	copy(w.Memory[offset:], data)
}

// Reset will reset the memory length, but keeps the memory capacity.
func (w *Writer) Reset() {
	if len(w.Memory) == 0 {
		return
	}
	w.Memory = w.Memory[:0]
}

// Bytes return the Karmem encoded bytes.
// It doesn't copy the content, and can't be re-used after Reset.
func (w *Writer) Bytes() []byte {
	return w.Memory
}

// Reader holds the buffer to read data from.
type Reader struct {
	Memory   []byte
	Pointer  unsafe.Pointer
	Size     uint64
	Min, Max uintptr
}

// NewReader creates a Reader using the existent slice.
// The slice is supposed to have, and begin with, a Karmem
// encoded structure.
//
// Reader is not current safe. You MUST not change the
// slice content while reading.
func NewReader(mem []byte) *Reader {
	if len(mem) == 0 {
		return &Reader{}
	}
	return &Reader{
		Memory:  mem,
		Size:    uint64(len(mem)),
		Pointer: unsafe.Pointer(&mem[0]),
		Min:     uintptr(unsafe.Pointer(&mem[0])),
		Max:     uintptr(unsafe.Pointer(&mem[len(mem)-1])),
	}
}

// IsValidOffset check if the current offset and size is valid
// and accessible within the bounds.
func (m *Reader) IsValidOffset(ptr, size uint32) bool {
	return m.Size >= uint64(ptr)+uint64(size)
}