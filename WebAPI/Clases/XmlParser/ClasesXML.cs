namespace WebAPI.Clases.XmlParser;



// NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/2005/Atom", IsNullable = false)]
public partial class feed {

    private string idField;

    private object titleField;

    private System.DateTime updatedField;

    private feedEntry[] entryField;

    private feedLink linkField;

    private string baseField;

    /// <remarks/>
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }

    /// <remarks/>
    public object title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public System.DateTime updated {
        get {
            return this.updatedField;
        }
        set {
            this.updatedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("entry")]
    public feedEntry[] entry {
        get {
            return this.entryField;
        }
        set {
            this.entryField = value;
        }
    }

    /// <remarks/>
    public feedLink link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
    public string @base {
        get {
            return this.baseField;
        }
        set {
            this.baseField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class feedEntry {

    private string idField;

    private feedEntryCategory categoryField;

    private feedEntryLink[] linkField;

    private object titleField;

    private System.DateTime updatedField;

    private feedEntryAuthor authorField;

    private feedEntryContent contentField;

    private string etagField;

    /// <remarks/>
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }

    /// <remarks/>
    public feedEntryCategory category {
        get {
            return this.categoryField;
        }
        set {
            this.categoryField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("link")]
    public feedEntryLink[] link {
        get {
            return this.linkField;
        }
        set {
            this.linkField = value;
        }
    }

    /// <remarks/>
    public object title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public System.DateTime updated {
        get {
            return this.updatedField;
        }
        set {
            this.updatedField = value;
        }
    }

    /// <remarks/>
    public feedEntryAuthor author {
        get {
            return this.authorField;
        }
        set {
            this.authorField = value;
        }
    }

    /// <remarks/>
    public feedEntryContent content {
        get {
            return this.contentField;
        }
        set {
            this.contentField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string etag {
        get {
            return this.etagField;
        }
        set {
            this.etagField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class feedEntryCategory {

    private string termField;

    private string schemeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string term {
        get {
            return this.termField;
        }
        set {
            this.termField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string scheme {
        get {
            return this.schemeField;
        }
        set {
            this.schemeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class feedEntryLink {

    private string relField;

    private string hrefField;

    private string typeField;

    private string titleField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rel {
        get {
            return this.relField;
        }
        set {
            this.relField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string href {
        get {
            return this.hrefField;
        }
        set {
            this.hrefField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class feedEntryAuthor {

    private object nameField;

    /// <remarks/>
    public object name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class feedEntryContent {

    private properties propertiesField;

    private string typeField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public properties properties {
        get {
            return this.propertiesField;
        }
        set {
            this.propertiesField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata", IsNullable = false)]
public partial class properties {

    private FileSystemObjectType fileSystemObjectTypeField;

    private Id idField;

    private ServerRedirectedEmbedUri serverRedirectedEmbedUriField;

    private object serverRedirectedEmbedUrlField;

    private string contentTypeIdField;

    private string titleField;

    private ComplianceAssetId complianceAssetIdField;

    private FechaInicio fechaInicioField;

    private FechaFin fechaFinField;

    private NumDias numDiasField;

    private string responsableField;

    private string estadoField;

    private Created createdField;

    private ID idField1;

    private Modified modifiedField;

    private AuthorId authorIdField;

    private EditorId editorIdField;

    private decimal oData__UIVersionStringField;

    private Attachments attachmentsField;

    private GUID gUIDField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public FileSystemObjectType FileSystemObjectType {
        get {
            return this.fileSystemObjectTypeField;
        }
        set {
            this.fileSystemObjectTypeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public Id Id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public ServerRedirectedEmbedUri ServerRedirectedEmbedUri {
        get {
            return this.serverRedirectedEmbedUriField;
        }
        set {
            this.serverRedirectedEmbedUriField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public object ServerRedirectedEmbedUrl {
        get {
            return this.serverRedirectedEmbedUrlField;
        }
        set {
            this.serverRedirectedEmbedUrlField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public string ContentTypeId {
        get {
            return this.contentTypeIdField;
        }
        set {
            this.contentTypeIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public string Title {
        get {
            return this.titleField;
        }
        set {
            this.titleField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public ComplianceAssetId ComplianceAssetId {
        get {
            return this.complianceAssetIdField;
        }
        set {
            this.complianceAssetIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public FechaInicio FechaInicio {
        get {
            return this.fechaInicioField;
        }
        set {
            this.fechaInicioField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public FechaFin FechaFin {
        get {
            return this.fechaFinField;
        }
        set {
            this.fechaFinField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public NumDias NumDias {
        get {
            return this.numDiasField;
        }
        set {
            this.numDiasField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public string Responsable {
        get {
            return this.responsableField;
        }
        set {
            this.responsableField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public string Estado {
        get {
            return this.estadoField;
        }
        set {
            this.estadoField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public Created Created {
        get {
            return this.createdField;
        }
        set {
            this.createdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public ID ID {
        get {
            return this.idField1;
        }
        set {
            this.idField1 = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public Modified Modified {
        get {
            return this.modifiedField;
        }
        set {
            this.modifiedField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public AuthorId AuthorId {
        get {
            return this.authorIdField;
        }
        set {
            this.authorIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public EditorId EditorId {
        get {
            return this.editorIdField;
        }
        set {
            this.editorIdField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public decimal OData__UIVersionString {
        get {
            return this.oData__UIVersionStringField;
        }
        set {
            this.oData__UIVersionStringField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public Attachments Attachments {
        get {
            return this.attachmentsField;
        }
        set {
            this.attachmentsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
    public GUID GUID {
        get {
            return this.gUIDField;
        }
        set {
            this.gUIDField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class FileSystemObjectType {

    private string typeField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class Id {

    private string typeField;

    private ushort valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public ushort Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class ServerRedirectedEmbedUri {

    private bool nullField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public bool @null {
        get {
            return this.nullField;
        }
        set {
            this.nullField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class ComplianceAssetId {

    private bool nullField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public bool @null {
        get {
            return this.nullField;
        }
        set {
            this.nullField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class FechaInicio {

    private string typeField;

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.DateTime Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class FechaFin {

    private string typeField;

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.DateTime Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class NumDias {

    private string typeField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class Created {

    private string typeField;

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.DateTime Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class ID {

    private string typeField;

    private ushort valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public ushort Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class Modified {

    private string typeField;

    private System.DateTime valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public System.DateTime Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class AuthorId {

    private string typeField;

    private uint valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public uint Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class EditorId {

    private string typeField;

    private byte valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public byte Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class Attachments {

    private string typeField;

    private bool valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public bool Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices", IsNullable = false)]
public partial class GUID {

    private string typeField;

    private string valueField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")]
    public string type {
        get {
            return this.typeField;
        }
        set {
            this.typeField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTextAttribute()]
    public string Value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/2005/Atom")]
public partial class feedLink {

    private string relField;

    private string hrefField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string rel {
        get {
            return this.relField;
        }
        set {
            this.relField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string href {
        get {
            return this.hrefField;
        }
        set {
            this.hrefField = value;
        }
    }
}


