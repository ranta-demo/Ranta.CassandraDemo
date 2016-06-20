/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using System;
using System.Text;
using FluentCassandra.Thrift.Protocol;

namespace FluentCassandra.Apache.Cassandra
{

  /// <summary>
  /// Basic unit of data within a ColumnFamily.
  /// @param name, the name by which this column is set and retrieved.  Maximum 64KB long.
  /// @param value. The data associated with the name.  Maximum 2GB long, but in practice you should limit it to small numbers of MB (since Thrift must read the full value into memory to operate on it).
  /// @param timestamp. The timestamp is used for conflict detection/resolution when two columns with same name need to be compared.
  /// @param ttl. An optional, positive delay (in seconds) after which the column will be automatically deleted.
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class Column : TBase
  {
    private byte[] _value;
    private long _timestamp;
    private int _ttl;

    public byte[] Name { get; set; }

    public byte[] Value
    {
      get
      {
        return _value;
      }
      set
      {
        __isset.value = true;
        this._value = value;
      }
    }

    public long Timestamp
    {
      get
      {
        return _timestamp;
      }
      set
      {
        __isset.timestamp = true;
        this._timestamp = value;
      }
    }

    public int Ttl
    {
      get
      {
        return _ttl;
      }
      set
      {
        __isset.ttl = true;
        this._ttl = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool value;
      public bool timestamp;
      public bool ttl;
    }

    public Column() {
    }

    public Column(byte[] name) : this() {
      this.Name = name;
    }

    public void Read (TProtocol iprot)
    {
      bool isset_name = false;
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              Name = iprot.ReadBinary();
              isset_name = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.String) {
              Value = iprot.ReadBinary();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              Timestamp = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.I32) {
              Ttl = iprot.ReadI32();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
      if (!isset_name)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("Column");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "name";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteBinary(Name);
      oprot.WriteFieldEnd();
      if (Value != null && __isset.value) {
        field.Name = "value";
        field.Type = TType.String;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteBinary(Value);
        oprot.WriteFieldEnd();
      }
      if (__isset.timestamp) {
        field.Name = "timestamp";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Timestamp);
        oprot.WriteFieldEnd();
      }
      if (__isset.ttl) {
        field.Name = "ttl";
        field.Type = TType.I32;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        oprot.WriteI32(Ttl);
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("Column(");
      sb.Append("Name: ");
      sb.Append(Name);
      sb.Append(",Value: ");
      sb.Append(Value);
      sb.Append(",Timestamp: ");
      sb.Append(Timestamp);
      sb.Append(",Ttl: ");
      sb.Append(Ttl);
      sb.Append(")");
      return sb.ToString();
    }

  }

}