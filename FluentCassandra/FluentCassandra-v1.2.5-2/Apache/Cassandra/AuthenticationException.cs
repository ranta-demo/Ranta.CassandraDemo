/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using System;
using System.Text;
using FluentCassandra.Thrift;
using FluentCassandra.Thrift.Protocol;

namespace FluentCassandra.Apache.Cassandra
{

  /// <summary>
  /// invalid authentication request (invalid keyspace, user does not exist, or credentials invalid)
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class AuthenticationException : TException, TBase
  {

    public string Why { get; set; }

    public AuthenticationException() {
    }

    public AuthenticationException(string why) : this() {
      this.Why = why;
    }

    public void Read (TProtocol iprot)
    {
      bool isset_why = false;
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
              Why = iprot.ReadString();
              isset_why = true;
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
      if (!isset_why)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("AuthenticationException");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "why";
      field.Type = TType.String;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteString(Why);
      oprot.WriteFieldEnd();
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("AuthenticationException(");
      sb.Append("Why: ");
      sb.Append(Why);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
