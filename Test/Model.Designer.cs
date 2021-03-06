﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]

namespace Test
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class AdvServicesEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new AdvServicesEntities object using the connection string found in the 'AdvServicesEntities' section of the application configuration file.
        /// </summary>
        public AdvServicesEntities() : base("name=AdvServicesEntities", "AdvServicesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AdvServicesEntities object.
        /// </summary>
        public AdvServicesEntities(string connectionString) : base(connectionString, "AdvServicesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AdvServicesEntities object.
        /// </summary>
        public AdvServicesEntities(EntityConnection connection) : base(connection, "AdvServicesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<email> emails
        {
            get
            {
                if ((_emails == null))
                {
                    _emails = base.CreateObjectSet<email>("emails");
                }
                return _emails;
            }
        }
        private ObjectSet<email> _emails;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<CheckMail> CheckMails
        {
            get
            {
                if ((_CheckMails == null))
                {
                    _CheckMails = base.CreateObjectSet<CheckMail>("CheckMails");
                }
                return _CheckMails;
            }
        }
        private ObjectSet<CheckMail> _CheckMails;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the emails EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToemails(email email)
        {
            base.AddObject("emails", email);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CheckMails EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCheckMails(CheckMail checkMail)
        {
            base.AddObject("CheckMails", checkMail);
        }

        #endregion
        #region Function Imports
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectResult<spSel_EmailList_Result> spSel_EmailList()
        {
            return base.ExecuteFunction<spSel_EmailList_Result>("spSel_EmailList");
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AdvServicesModel", Name="CheckMail")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CheckMail : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CheckMail object.
        /// </summary>
        /// <param name="advID">Initial value of the AdvID property.</param>
        /// <param name="sentAccID">Initial value of the SentAccID property.</param>
        /// <param name="receivedAccID">Initial value of the ReceivedAccID property.</param>
        /// <param name="typeID">Initial value of the TypeID property.</param>
        public static CheckMail CreateCheckMail(global::System.Int32 advID, global::System.Int32 sentAccID, global::System.Int32 receivedAccID, global::System.Int32 typeID)
        {
            CheckMail checkMail = new CheckMail();
            checkMail.AdvID = advID;
            checkMail.SentAccID = sentAccID;
            checkMail.ReceivedAccID = receivedAccID;
            checkMail.TypeID = typeID;
            return checkMail;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 AdvID
        {
            get
            {
                return _AdvID;
            }
            set
            {
                if (_AdvID != value)
                {
                    OnAdvIDChanging(value);
                    ReportPropertyChanging("AdvID");
                    _AdvID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("AdvID");
                    OnAdvIDChanged();
                }
            }
        }
        private global::System.Int32 _AdvID;
        partial void OnAdvIDChanging(global::System.Int32 value);
        partial void OnAdvIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 SentAccID
        {
            get
            {
                return _SentAccID;
            }
            set
            {
                OnSentAccIDChanging(value);
                ReportPropertyChanging("SentAccID");
                _SentAccID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SentAccID");
                OnSentAccIDChanged();
            }
        }
        private global::System.Int32 _SentAccID;
        partial void OnSentAccIDChanging(global::System.Int32 value);
        partial void OnSentAccIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ReceivedAccID
        {
            get
            {
                return _ReceivedAccID;
            }
            set
            {
                OnReceivedAccIDChanging(value);
                ReportPropertyChanging("ReceivedAccID");
                _ReceivedAccID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ReceivedAccID");
                OnReceivedAccIDChanged();
            }
        }
        private global::System.Int32 _ReceivedAccID;
        partial void OnReceivedAccIDChanging(global::System.Int32 value);
        partial void OnReceivedAccIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 TypeID
        {
            get
            {
                return _TypeID;
            }
            set
            {
                OnTypeIDChanging(value);
                ReportPropertyChanging("TypeID");
                _TypeID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TypeID");
                OnTypeIDChanged();
            }
        }
        private global::System.Int32 _TypeID;
        partial void OnTypeIDChanging(global::System.Int32 value);
        partial void OnTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Header
        {
            get
            {
                return _Header;
            }
            set
            {
                OnHeaderChanging(value);
                ReportPropertyChanging("Header");
                _Header = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Header");
                OnHeaderChanged();
            }
        }
        private global::System.String _Header;
        partial void OnHeaderChanging(global::System.String value);
        partial void OnHeaderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Contain
        {
            get
            {
                return _Contain;
            }
            set
            {
                OnContainChanging(value);
                ReportPropertyChanging("Contain");
                _Contain = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Contain");
                OnContainChanged();
            }
        }
        private global::System.String _Contain;
        partial void OnContainChanging(global::System.String value);
        partial void OnContainChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                OnCreateDateChanging(value);
                ReportPropertyChanging("CreateDate");
                _CreateDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CreateDate");
                OnCreateDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _CreateDate;
        partial void OnCreateDateChanging(Nullable<global::System.DateTime> value);
        partial void OnCreateDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsHide
        {
            get
            {
                return _IsHide;
            }
            set
            {
                OnIsHideChanging(value);
                ReportPropertyChanging("IsHide");
                _IsHide = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsHide");
                OnIsHideChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsHide;
        partial void OnIsHideChanging(Nullable<global::System.Boolean> value);
        partial void OnIsHideChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Boolean> IsClose
        {
            get
            {
                return _IsClose;
            }
            set
            {
                OnIsCloseChanging(value);
                ReportPropertyChanging("IsClose");
                _IsClose = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("IsClose");
                OnIsCloseChanged();
            }
        }
        private Nullable<global::System.Boolean> _IsClose;
        partial void OnIsCloseChanging(Nullable<global::System.Boolean> value);
        partial void OnIsCloseChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String IP
        {
            get
            {
                return _IP;
            }
            set
            {
                OnIPChanging(value);
                ReportPropertyChanging("IP");
                _IP = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("IP");
                OnIPChanged();
            }
        }
        private global::System.String _IP;
        partial void OnIPChanging(global::System.String value);
        partial void OnIPChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AdvServicesModel", Name="email")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class email : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new email object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static email Createemail(global::System.Int32 id)
        {
            email email = new email();
            email.Id = id;
            return email;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String EmailAddress
        {
            get
            {
                return _EmailAddress;
            }
            set
            {
                OnEmailAddressChanging(value);
                ReportPropertyChanging("EmailAddress");
                _EmailAddress = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("EmailAddress");
                OnEmailAddressChanged();
            }
        }
        private global::System.String _EmailAddress;
        partial void OnEmailAddressChanging(global::System.String value);
        partial void OnEmailAddressChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Byte> Type
        {
            get
            {
                return _Type;
            }
            set
            {
                OnTypeChanging(value);
                ReportPropertyChanging("Type");
                _Type = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Type");
                OnTypeChanged();
            }
        }
        private Nullable<global::System.Byte> _Type;
        partial void OnTypeChanging(Nullable<global::System.Byte> value);
        partial void OnTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String YahooNick
        {
            get
            {
                return _YahooNick;
            }
            set
            {
                OnYahooNickChanging(value);
                ReportPropertyChanging("YahooNick");
                _YahooNick = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("YahooNick");
                OnYahooNickChanged();
            }
        }
        private global::System.String _YahooNick;
        partial void OnYahooNickChanging(global::System.String value);
        partial void OnYahooNickChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> UpdatedTime
        {
            get
            {
                return _UpdatedTime;
            }
            set
            {
                OnUpdatedTimeChanging(value);
                ReportPropertyChanging("UpdatedTime");
                _UpdatedTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("UpdatedTime");
                OnUpdatedTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _UpdatedTime;
        partial void OnUpdatedTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnUpdatedTimeChanged();

        #endregion
    
    }

    #endregion
    #region ComplexTypes
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmComplexTypeAttribute(NamespaceName="AdvServicesModel", Name="spSel_EmailList_Result")]
    [DataContractAttribute(IsReference=true)]
    [Serializable()]
    public partial class spSel_EmailList_Result : ComplexObject
    {
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> id
        {
            get
            {
                return _id;
            }
            set
            {
                OnidChanging(value);
                ReportPropertyChanging("id");
                _id = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("id");
                OnidChanged();
            }
        }
        private Nullable<global::System.Int32> _id;
        partial void OnidChanging(Nullable<global::System.Int32> value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String yahoonick
        {
            get
            {
                return _yahoonick;
            }
            set
            {
                OnyahoonickChanging(value);
                ReportPropertyChanging("yahoonick");
                _yahoonick = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("yahoonick");
                OnyahoonickChanged();
            }
        }
        private global::System.String _yahoonick;
        partial void OnyahoonickChanging(global::System.String value);
        partial void OnyahoonickChanged();

        #endregion
    }

    #endregion
    
}
