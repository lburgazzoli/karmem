
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Karmem;

namespace km;

public static unsafe class _Globals
{
    private static long _largest = 152;
    private static void* _null = null;
    private static Karmem.Reader? _nullReader = null;

    public static void* Null()
    {
        if (_null == null)
        {
            var n = Marshal.AllocHGlobal(0);
            Unsafe.InitBlockUnaligned(n.ToPointer(), 0, (uint)_largest);
            _null = n.ToPointer();
        }
        return _null;
    }
    public static Karmem.Reader NullReader()
    {
        _nullReader ??= Karmem.Reader.NewReader(new IntPtr((long)Null()), _largest, _largest);
        return _nullReader.Value;
    }
}

public enum Color : byte {
    Red = 0,
    Green = 1,
    Blue = 2,
}
    
public enum Team : byte {
    Humans = 0,
    Orcs = 1,
    Zombies = 2,
    Robots = 3,
    Aliens = 4,
}
    
public enum PacketIdentifier : ulong {
    Vec3 = 10268726485798425099,
    WeaponData = 15342010214468761012,
    Weapon = 8029074423243608167,
    MonsterData = 12254962724431809041,
    Monster = 5593793986513565154,
    Monsters = 14096677544474027661,
}
    
public unsafe struct Vec3 {
    public float _X = 0;
    public float _Y = 0;
    public float _Z = 0;

    public Vec3() {}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Vec3 NewVec3() {
        return new Vec3();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PacketIdentifier GetPacketIdentifier() {
        return PacketIdentifier.Vec3;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() {
        this.ReadAsRoot(_Globals.NullReader());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool WriteAsRoot(Karmem.Writer writer) {
        return this.Write(writer, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Write(Karmem.Writer writer, uint start) {
        var offset = start;
        var size = (uint)16;
        if (offset == 0) {
            offset = writer.Alloc(size);
            if (offset == uint.MaxValue) {
                return false;
            }
        }
        var __XOffset = offset+0;
        writer.WriteAt(__XOffset, this._X);
        var __YOffset = offset+4;
        writer.WriteAt(__YOffset, this._Y);
        var __ZOffset = offset+8;
        writer.WriteAt(__ZOffset, this._Z);

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadAsRoot(Karmem.Reader reader) {
        this.Read(Vec3Viewer.NewVec3Viewer(reader, 0), reader);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Read(Vec3Viewer viewer, Karmem.Reader reader) {
        this._X = viewer.X();
        this._Y = viewer.Y();
        this._Z = viewer.Z();
    }
}
public unsafe struct WeaponData {
    public int _Damage = 0;
    public int _Range = 0;

    public WeaponData() {}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static WeaponData NewWeaponData() {
        return new WeaponData();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PacketIdentifier GetPacketIdentifier() {
        return PacketIdentifier.WeaponData;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() {
        this.ReadAsRoot(_Globals.NullReader());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool WriteAsRoot(Karmem.Writer writer) {
        return this.Write(writer, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Write(Karmem.Writer writer, uint start) {
        var offset = start;
        var size = (uint)16;
        if (offset == 0) {
            offset = writer.Alloc(size);
            if (offset == uint.MaxValue) {
                return false;
            }
        }
        writer.WriteAt(offset, (uint)12);
        var __DamageOffset = offset+4;
        writer.WriteAt(__DamageOffset, this._Damage);
        var __RangeOffset = offset+8;
        writer.WriteAt(__RangeOffset, this._Range);

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadAsRoot(Karmem.Reader reader) {
        this.Read(WeaponDataViewer.NewWeaponDataViewer(reader, 0), reader);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Read(WeaponDataViewer viewer, Karmem.Reader reader) {
        this._Damage = viewer.Damage();
        this._Range = viewer.Range();
    }
}
public unsafe struct Weapon {
    public WeaponData _Data = new WeaponData();

    public Weapon() {}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Weapon NewWeapon() {
        return new Weapon();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PacketIdentifier GetPacketIdentifier() {
        return PacketIdentifier.Weapon;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() {
        this.ReadAsRoot(_Globals.NullReader());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool WriteAsRoot(Karmem.Writer writer) {
        return this.Write(writer, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Write(Karmem.Writer writer, uint start) {
        var offset = start;
        var size = (uint)8;
        if (offset == 0) {
            offset = writer.Alloc(size);
            if (offset == uint.MaxValue) {
                return false;
            }
        }
        var __DataSize = (uint)16;
        var __DataOffset = writer.Alloc(__DataSize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+0, (uint)__DataOffset);
            if (!this._Data.Write(writer, __DataOffset)) {
                return false;
            }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadAsRoot(Karmem.Reader reader) {
        this.Read(WeaponViewer.NewWeaponViewer(reader, 0), reader);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Read(WeaponViewer viewer, Karmem.Reader reader) {
        this._Data.Read(viewer.Data(reader), reader);
    }
}
public unsafe struct MonsterData {
    public Vec3 _Pos = new Vec3();
    public short _Mana = 0;
    public short _Health = 0;
    public string _Name = "";
    public Team _Team = 0;
    public List<byte> _Inventory = new List<byte>();
    public Color _Color = 0;
    public List<double> _Hitbox = new List<double>();
    public List<int> _Status = new List<int>();
    public List<Weapon> _Weapons = new List<Weapon>();
    public List<Vec3> _Path = new List<Vec3>();
    public bool _IsAlive = false;

    public MonsterData() {}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MonsterData NewMonsterData() {
        return new MonsterData();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PacketIdentifier GetPacketIdentifier() {
        return PacketIdentifier.MonsterData;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() {
        this.ReadAsRoot(_Globals.NullReader());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool WriteAsRoot(Karmem.Writer writer) {
        return this.Write(writer, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Write(Karmem.Writer writer, uint start) {
        var offset = start;
        var size = (uint)152;
        if (offset == 0) {
            offset = writer.Alloc(size);
            if (offset == uint.MaxValue) {
                return false;
            }
        }
        writer.WriteAt(offset, (uint)147);
        var __PosOffset = offset+4;
            if (!this._Pos.Write(writer, __PosOffset)) {
                return false;
            }
        var __ManaOffset = offset+20;
        writer.WriteAt(__ManaOffset, this._Mana);
        var __HealthOffset = offset+22;
        writer.WriteAt(__HealthOffset, this._Health);
        var __NameSize = (uint)(4 * this._Name.Length);
        var __NameOffset = writer.Alloc(__NameSize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+24, (uint)__NameOffset);
        writer.WriteAt(offset+24 + 4 + 4, (uint)1);
        var __NameStringSize = writer.WriteAt(__NameOffset, this._Name);
        writer.WriteAt(offset+24 + 4, (uint)__NameStringSize);
        var __TeamOffset = offset+36;
        writer.WriteAt(__TeamOffset, (long)this._Team);
        var __InventorySize = (uint)(1 * this._Inventory.Count);
        var __InventoryOffset = writer.Alloc(__InventorySize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+37, (uint)__InventoryOffset);
        writer.WriteAt(offset+37 + 4, (uint)__InventorySize);
        writer.WriteAt(offset+37 + 4 + 4, (uint)1);
        for (var i = 0; i < this._Inventory.Count; i++) {
            writer.WriteAt(__InventoryOffset, this._Inventory[i]);
            __InventoryOffset += 1;
        }
        var __ColorOffset = offset+49;
        writer.WriteAt(__ColorOffset, (long)this._Color);
        var __HitboxOffset = offset+50;
        for (var i = 0; i < 5; i++) {
            if (i < this._Hitbox.Count) {
                writer.WriteAt(__HitboxOffset, this._Hitbox[i]);
            } else {
                writer.WriteAt(__HitboxOffset, 0);
            }
            __HitboxOffset += 8;
        }
        var __StatusSize = (uint)(4 * this._Status.Count);
        var __StatusOffset = writer.Alloc(__StatusSize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+90, (uint)__StatusOffset);
        writer.WriteAt(offset+90 + 4, (uint)__StatusSize);
        writer.WriteAt(offset+90 + 4 + 4, (uint)4);
        for (var i = 0; i < this._Status.Count; i++) {
            writer.WriteAt(__StatusOffset, this._Status[i]);
            __StatusOffset += 4;
        }
        var __WeaponsOffset = offset+102;
            for (var i = 0; i < this._Weapons.Count; i++) {
                if (!this._Weapons[i].Write(writer, __WeaponsOffset)) {
                    return false;
                }
                __WeaponsOffset += 8;
            }
        var __PathSize = (uint)(16 * this._Path.Count);
        var __PathOffset = writer.Alloc(__PathSize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+134, (uint)__PathOffset);
        writer.WriteAt(offset+134 + 4, (uint)__PathSize);
        writer.WriteAt(offset+134 + 4 + 4, (uint)16);
            for (var i = 0; i < this._Path.Count; i++) {
                if (!this._Path[i].Write(writer, __PathOffset)) {
                    return false;
                }
                __PathOffset += 16;
            }
        var __IsAliveOffset = offset+146;
        writer.WriteAt(__IsAliveOffset, this._IsAlive);

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadAsRoot(Karmem.Reader reader) {
        this.Read(MonsterDataViewer.NewMonsterDataViewer(reader, 0), reader);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Read(MonsterDataViewer viewer, Karmem.Reader reader) {
        this._Pos.Read(viewer.Pos(), reader);
        this._Mana = viewer.Mana();
        this._Health = viewer.Health();
        this._Name = viewer.Name(reader);
        this._Team = (Team)(viewer.Team());
        var __InventorySlice = viewer.Inventory(reader);
        var __InventoryLen = __InventorySlice.Length;
        if (this._Inventory.Count > (int)__InventoryLen) {
            this._Inventory.Clear();
        }
        if ((int)__InventoryLen > this._Inventory.Capacity) {
            this._Inventory.EnsureCapacity((int)__InventoryLen);
        }
        for (var i = 0; i < __InventoryLen; i++) {
            if (i >= this._Inventory.Count) {
                this._Inventory.Add(__InventorySlice[i]);
            } else {
                this._Inventory[(int)i] = __InventorySlice[i];
            }
        }
        for (var i = (int)__InventoryLen; i < this._Inventory.Count; i++) {
            this._Inventory[i] = 0;
        }
        this._Color = (Color)(viewer.Color());
        var __HitboxSlice = viewer.Hitbox();
        var __HitboxLen = __HitboxSlice.Length;
        for (var i = 0; i < __HitboxLen; i++) {
            if (i >= this._Hitbox.Count) {
                this._Hitbox.Add(__HitboxSlice[i]);
            } else {
                this._Hitbox[(int)i] = __HitboxSlice[i];
            }
        }
        for (var i = (int)__HitboxLen; i < this._Hitbox.Count; i++) {
            this._Hitbox[i] = 0;
        }
        var __StatusSlice = viewer.Status(reader);
        var __StatusLen = __StatusSlice.Length;
        if (this._Status.Count > (int)__StatusLen) {
            this._Status.Clear();
        }
        if ((int)__StatusLen > this._Status.Capacity) {
            this._Status.EnsureCapacity((int)__StatusLen);
        }
        for (var i = 0; i < __StatusLen; i++) {
            if (i >= this._Status.Count) {
                this._Status.Add(__StatusSlice[i]);
            } else {
                this._Status[(int)i] = __StatusSlice[i];
            }
        }
        for (var i = (int)__StatusLen; i < this._Status.Count; i++) {
            this._Status[i] = 0;
        }
        var __WeaponsSlice = viewer.Weapons();
        var __WeaponsLen = __WeaponsSlice.Length;
        var __WeaponsSpan = CollectionsMarshal.AsSpan(this._Weapons);
        for (var i = 0; i < __WeaponsLen; i++) {
            if (i >= this._Weapons.Count) {
                var __WeaponsItem = new Weapon();
                __WeaponsItem.Read(__WeaponsSlice[i], reader);
                this._Weapons.Add(__WeaponsItem);
            } else {
                ref var __WeaponsItem = ref __WeaponsSpan[(int)i];
                __WeaponsItem.Read(__WeaponsSlice[i], reader);
            }
        }
        for (var i = (int)__WeaponsLen; i < this._Weapons.Count; i++) {
            ref var __WeaponsItem = ref __WeaponsSpan[(int)i];
            __WeaponsItem.Reset();
        }
        var __PathSlice = viewer.Path(reader);
        var __PathLen = __PathSlice.Length;
        if (this._Path.Count > (int)__PathLen) {
            this._Path.Clear();
        }
        if ((int)__PathLen > this._Path.Capacity) {
            this._Path.EnsureCapacity((int)__PathLen);
        }
        var __PathSpan = CollectionsMarshal.AsSpan(this._Path);
        for (var i = 0; i < __PathLen; i++) {
            if (i >= this._Path.Count) {
                var __PathItem = new Vec3();
                __PathItem.Read(__PathSlice[i], reader);
                this._Path.Add(__PathItem);
            } else {
                ref var __PathItem = ref __PathSpan[(int)i];
                __PathItem.Read(__PathSlice[i], reader);
            }
        }
        for (var i = (int)__PathLen; i < this._Path.Count; i++) {
            ref var __PathItem = ref __PathSpan[(int)i];
            __PathItem.Reset();
        }
        this._IsAlive = viewer.IsAlive();
    }
}
public unsafe struct Monster {
    public MonsterData _Data = new MonsterData();

    public Monster() {}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Monster NewMonster() {
        return new Monster();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PacketIdentifier GetPacketIdentifier() {
        return PacketIdentifier.Monster;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() {
        this.ReadAsRoot(_Globals.NullReader());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool WriteAsRoot(Karmem.Writer writer) {
        return this.Write(writer, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Write(Karmem.Writer writer, uint start) {
        var offset = start;
        var size = (uint)8;
        if (offset == 0) {
            offset = writer.Alloc(size);
            if (offset == uint.MaxValue) {
                return false;
            }
        }
        var __DataSize = (uint)152;
        var __DataOffset = writer.Alloc(__DataSize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+0, (uint)__DataOffset);
            if (!this._Data.Write(writer, __DataOffset)) {
                return false;
            }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadAsRoot(Karmem.Reader reader) {
        this.Read(MonsterViewer.NewMonsterViewer(reader, 0), reader);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Read(MonsterViewer viewer, Karmem.Reader reader) {
        this._Data.Read(viewer.Data(reader), reader);
    }
}
public unsafe struct Monsters {
    public List<Monster> _Monsters = new List<Monster>();

    public Monsters() {}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Monsters NewMonsters() {
        return new Monsters();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static PacketIdentifier GetPacketIdentifier() {
        return PacketIdentifier.Monsters;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Reset() {
        this.ReadAsRoot(_Globals.NullReader());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool WriteAsRoot(Karmem.Writer writer) {
        return this.Write(writer, 0);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool Write(Karmem.Writer writer, uint start) {
        var offset = start;
        var size = (uint)24;
        if (offset == 0) {
            offset = writer.Alloc(size);
            if (offset == uint.MaxValue) {
                return false;
            }
        }
        writer.WriteAt(offset, (uint)16);
        var __MonstersSize = (uint)(8 * this._Monsters.Count);
        var __MonstersOffset = writer.Alloc(__MonstersSize);
        if (offset == uint.MaxValue) {
            return false;
        }
        writer.WriteAt(offset+4, (uint)__MonstersOffset);
        writer.WriteAt(offset+4 + 4, (uint)__MonstersSize);
        writer.WriteAt(offset+4 + 4 + 4, (uint)8);
            for (var i = 0; i < this._Monsters.Count; i++) {
                if (!this._Monsters[i].Write(writer, __MonstersOffset)) {
                    return false;
                }
                __MonstersOffset += 8;
            }

        return true;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void ReadAsRoot(Karmem.Reader reader) {
        this.Read(MonstersViewer.NewMonstersViewer(reader, 0), reader);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Read(MonstersViewer viewer, Karmem.Reader reader) {
        var __MonstersSlice = viewer.Monsters(reader);
        var __MonstersLen = __MonstersSlice.Length;
        if (this._Monsters.Count > (int)__MonstersLen) {
            this._Monsters.Clear();
        }
        if ((int)__MonstersLen > this._Monsters.Capacity) {
            this._Monsters.EnsureCapacity((int)__MonstersLen);
        }
        var __MonstersSpan = CollectionsMarshal.AsSpan(this._Monsters);
        for (var i = 0; i < __MonstersLen; i++) {
            if (i >= this._Monsters.Count) {
                var __MonstersItem = new Monster();
                __MonstersItem.Read(__MonstersSlice[i], reader);
                this._Monsters.Add(__MonstersItem);
            } else {
                ref var __MonstersItem = ref __MonstersSpan[(int)i];
                __MonstersItem.Read(__MonstersSlice[i], reader);
            }
        }
        for (var i = (int)__MonstersLen; i < this._Monsters.Count; i++) {
            ref var __MonstersItem = ref __MonstersSpan[(int)i];
            __MonstersItem.Reset();
        }
    }
}

[StructLayout(LayoutKind.Sequential, Pack=0, Size=16)]
public unsafe struct Vec3Viewer {
    private readonly long _0;
    private readonly long _1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref Vec3Viewer NewVec3Viewer(Karmem.Reader reader, uint offset) {
        if (!reader.IsValidOffset(offset, 16)) {
            return ref *(Vec3Viewer*)_Globals.Null();
        }
        ref Vec3Viewer v = ref *(Vec3Viewer*)(reader.MemoryPointer + offset);
        return ref v;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private uint KarmemSizeOf() {
        return 16;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float X() {
        return *(float*)((nuint)Unsafe.AsPointer(ref this) + 0);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Y() {
        return *(float*)((nuint)Unsafe.AsPointer(ref this) + 4);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public float Z() {
        return *(float*)((nuint)Unsafe.AsPointer(ref this) + 8);
    }
}
    
[StructLayout(LayoutKind.Sequential, Pack=0, Size=16)]
public unsafe struct WeaponDataViewer {
    private readonly long _0;
    private readonly long _1;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref WeaponDataViewer NewWeaponDataViewer(Karmem.Reader reader, uint offset) {
        if (!reader.IsValidOffset(offset, 8)) {
            return ref *(WeaponDataViewer*)_Globals.Null();
        }
        ref WeaponDataViewer v = ref *(WeaponDataViewer*)(reader.MemoryPointer + offset);
        if (!reader.IsValidOffset(offset, v.KarmemSizeOf())) {
            return ref *(WeaponDataViewer*)_Globals.Null();
        }
        return ref v;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private uint KarmemSizeOf() {
        return *(uint*)Unsafe.AsPointer(ref this);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Damage() {
        if (4 + 4 > this.KarmemSizeOf()) {
            return 0;
        }
        return *(int*)((nuint)Unsafe.AsPointer(ref this) + 4);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Range() {
        if (8 + 4 > this.KarmemSizeOf()) {
            return 0;
        }
        return *(int*)((nuint)Unsafe.AsPointer(ref this) + 8);
    }
}
    
[StructLayout(LayoutKind.Sequential, Pack=0, Size=8)]
public unsafe struct WeaponViewer {
    private readonly long _0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref WeaponViewer NewWeaponViewer(Karmem.Reader reader, uint offset) {
        if (!reader.IsValidOffset(offset, 8)) {
            return ref *(WeaponViewer*)_Globals.Null();
        }
        ref WeaponViewer v = ref *(WeaponViewer*)(reader.MemoryPointer + offset);
        return ref v;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private uint KarmemSizeOf() {
        return 8;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref WeaponDataViewer Data(Karmem.Reader reader) {
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 0);
        return ref WeaponDataViewer.NewWeaponDataViewer(reader, offset);
    }
}
    
[StructLayout(LayoutKind.Sequential, Pack=0, Size=152)]
public unsafe struct MonsterDataViewer {
    private readonly long _0;
    private readonly long _1;
    private readonly long _2;
    private readonly long _3;
    private readonly long _4;
    private readonly long _5;
    private readonly long _6;
    private readonly long _7;
    private readonly long _8;
    private readonly long _9;
    private readonly long _10;
    private readonly long _11;
    private readonly long _12;
    private readonly long _13;
    private readonly long _14;
    private readonly long _15;
    private readonly long _16;
    private readonly long _17;
    private readonly long _18;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref MonsterDataViewer NewMonsterDataViewer(Karmem.Reader reader, uint offset) {
        if (!reader.IsValidOffset(offset, 8)) {
            return ref *(MonsterDataViewer*)_Globals.Null();
        }
        ref MonsterDataViewer v = ref *(MonsterDataViewer*)(reader.MemoryPointer + offset);
        if (!reader.IsValidOffset(offset, v.KarmemSizeOf())) {
            return ref *(MonsterDataViewer*)_Globals.Null();
        }
        return ref v;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private uint KarmemSizeOf() {
        return *(uint*)Unsafe.AsPointer(ref this);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref Vec3Viewer Pos() {
        if (4 + 16 > this.KarmemSizeOf()) {
            return ref *(Vec3Viewer*)(_Globals.Null());
        }
        return ref *(Vec3Viewer*)((nuint)Unsafe.AsPointer(ref this) + 4);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short Mana() {
        if (20 + 2 > this.KarmemSizeOf()) {
            return 0;
        }
        return *(short*)((nuint)Unsafe.AsPointer(ref this) + 20);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public short Health() {
        if (22 + 2 > this.KarmemSizeOf()) {
            return 0;
        }
        return *(short*)((nuint)Unsafe.AsPointer(ref this) + 22);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string Name(Karmem.Reader reader) {
        if (24 + 12 > this.KarmemSizeOf()) {
            return "";
        }
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 24);
        var size = *(uint*)((uint)Unsafe.AsPointer(ref this) + 24 + 4);
        if (!reader.IsValidOffset(offset, size)) {
            return "";
        }
        var length = size / 1;
        if (length > 512) {
            length = 512;
        }
        return Marshal.PtrToStringUTF8((IntPtr)(reader.Memory.ToInt64() + offset), (int)length);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Team Team() {
        if (36 + 1 > this.KarmemSizeOf()) {
            return 0;
        }
        return *(Team*)((nuint)Unsafe.AsPointer(ref this) + 36);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<byte> Inventory(Karmem.Reader reader) {
        if (37 + 12 > this.KarmemSizeOf()) {
            return new ReadOnlySpan<byte>(_Globals.Null(), 0);
        }
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 37);
        var size = *(uint*)((uint)Unsafe.AsPointer(ref this) + 37 + 4);
        if (!reader.IsValidOffset(offset, size)) {
            return new ReadOnlySpan<byte>();
        }
        var length = size / 1;
        if (length > 128) {
            length = 128;
        }
        return new ReadOnlySpan<byte>((void*)(reader.MemoryPointer + offset), (int)length);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Color Color() {
        if (49 + 1 > this.KarmemSizeOf()) {
            return 0;
        }
        return *(Color*)((nuint)Unsafe.AsPointer(ref this) + 49);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<double> Hitbox() {
        if (50 + 40 > this.KarmemSizeOf()) {
            return new ReadOnlySpan<double>(_Globals.Null(), 0);
        }
        return new ReadOnlySpan<double>((void*)((nuint)Unsafe.AsPointer(ref this) + 50), 5);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<int> Status(Karmem.Reader reader) {
        if (90 + 12 > this.KarmemSizeOf()) {
            return new ReadOnlySpan<int>(_Globals.Null(), 0);
        }
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 90);
        var size = *(uint*)((uint)Unsafe.AsPointer(ref this) + 90 + 4);
        if (!reader.IsValidOffset(offset, size)) {
            return new ReadOnlySpan<int>();
        }
        var length = size / 4;
        if (length > 10) {
            length = 10;
        }
        return new ReadOnlySpan<int>((void*)(reader.MemoryPointer + offset), (int)length);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<WeaponViewer> Weapons() {
        if (102 + 32 > this.KarmemSizeOf()) {
            return new ReadOnlySpan<WeaponViewer>(_Globals.Null(), 0);
        }
        return new ReadOnlySpan<WeaponViewer>((void*)((nuint)Unsafe.AsPointer(ref this) + 102), 4);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<Vec3Viewer> Path(Karmem.Reader reader) {
        if (134 + 12 > this.KarmemSizeOf()) {
            return new ReadOnlySpan<Vec3Viewer>(_Globals.Null(), 0);
        }
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 134);
        var size = *(uint*)((uint)Unsafe.AsPointer(ref this) + 134 + 4);
        if (!reader.IsValidOffset(offset, size)) {
            return new ReadOnlySpan<Vec3Viewer>();
        }
        var length = size / 16;
        if (length > 2000) {
            length = 2000;
        }
        return new ReadOnlySpan<Vec3Viewer>((void*)(reader.MemoryPointer + offset), (int)length);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsAlive() {
        if (146 + 1 > this.KarmemSizeOf()) {
            return false;
        }
        return *(bool*)((nuint)Unsafe.AsPointer(ref this) + 146);
    }
}
    
[StructLayout(LayoutKind.Sequential, Pack=0, Size=8)]
public unsafe struct MonsterViewer {
    private readonly long _0;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref MonsterViewer NewMonsterViewer(Karmem.Reader reader, uint offset) {
        if (!reader.IsValidOffset(offset, 8)) {
            return ref *(MonsterViewer*)_Globals.Null();
        }
        ref MonsterViewer v = ref *(MonsterViewer*)(reader.MemoryPointer + offset);
        return ref v;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private uint KarmemSizeOf() {
        return 8;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ref MonsterDataViewer Data(Karmem.Reader reader) {
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 0);
        return ref MonsterDataViewer.NewMonsterDataViewer(reader, offset);
    }
}
    
[StructLayout(LayoutKind.Sequential, Pack=0, Size=24)]
public unsafe struct MonstersViewer {
    private readonly long _0;
    private readonly long _1;
    private readonly long _2;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref MonstersViewer NewMonstersViewer(Karmem.Reader reader, uint offset) {
        if (!reader.IsValidOffset(offset, 8)) {
            return ref *(MonstersViewer*)_Globals.Null();
        }
        ref MonstersViewer v = ref *(MonstersViewer*)(reader.MemoryPointer + offset);
        if (!reader.IsValidOffset(offset, v.KarmemSizeOf())) {
            return ref *(MonstersViewer*)_Globals.Null();
        }
        return ref v;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private uint KarmemSizeOf() {
        return *(uint*)Unsafe.AsPointer(ref this);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<MonsterViewer> Monsters(Karmem.Reader reader) {
        if (4 + 12 > this.KarmemSizeOf()) {
            return new ReadOnlySpan<MonsterViewer>(_Globals.Null(), 0);
        }
        var offset = *(uint*)((uint)Unsafe.AsPointer(ref this) + 4);
        var size = *(uint*)((uint)Unsafe.AsPointer(ref this) + 4 + 4);
        if (!reader.IsValidOffset(offset, size)) {
            return new ReadOnlySpan<MonsterViewer>();
        }
        var length = size / 8;
        if (length > 2000) {
            length = 2000;
        }
        return new ReadOnlySpan<MonsterViewer>((void*)(reader.MemoryPointer + offset), (int)length);
    }
}
    
