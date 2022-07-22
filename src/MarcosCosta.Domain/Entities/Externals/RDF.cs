
// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
public partial class RDF
{

    private channel channelField;

    private item[] itemField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://purl.org/rss/1.0/")]
    public channel channel
    {
        get
        {
            return this.channelField;
        }
        set
        {
            this.channelField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("item", Namespace = "http://purl.org/rss/1.0/")]
    public item[] item
    {
        get
        {
            return this.itemField;
        }
        set
        {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.org/rss/1.0/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://purl.org/rss/1.0/", IsNullable = false)]
public partial class channel
{

    private string titleField;

    private string linkField;

    private string descriptionField;

    private channelItems itemsField;

    private System.DateTime dateField;

    private string languageField;

    private string rightsField;

    private string aboutField;

    /// <remarks/>
    public string title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public string link
    {
        get
        {
            return this.linkField;
        }
        set
        {
            this.linkField = value;
        }
    }

    /// <remarks/>
    public string description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    public channelItems items
    {
        get
        {
            return this.itemsField;
        }
        set
        {
            this.itemsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://purl.org/dc/elements/1.1/")]
    public System.DateTime date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://purl.org/dc/elements/1.1/")]
    public string language
    {
        get
        {
            return this.languageField;
        }
        set
        {
            this.languageField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://purl.org/dc/elements/1.1/")]
    public string rights
    {
        get
        {
            return this.rightsField;
        }
        set
        {
            this.rightsField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public string about
    {
        get
        {
            return this.aboutField;
        }
        set
        {
            this.aboutField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.org/rss/1.0/")]
public partial class channelItems
{

    private SeqLI[] seqField;

    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    [System.Xml.Serialization.XmlArrayItemAttribute("li", IsNullable = false)]
    public SeqLI[] Seq
    {
        get
        {
            return this.seqField;
        }
        set
        {
            this.seqField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
public partial class SeqLI
{

    private string resourceField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
    public string resource
    {
        get
        {
            return this.resourceField;
        }
        set
        {
            this.resourceField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://purl.org/rss/1.0/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://purl.org/rss/1.0/", IsNullable = false)]
public partial class item
{

    private string titleField;

    private string linkField;

    private string descriptionField;

    private System.DateTime dateField;

    private string aboutField;

    /// <remarks/>
    public string title
    {
        get
        {
            return this.titleField;
        }
        set
        {
            this.titleField = value;
        }
    }

    /// <remarks/>
    public string link
    {
        get
        {
            return this.linkField;
        }
        set
        {
            this.linkField = value;
        }
    }

    /// <remarks/>
    public string description
    {
        get
        {
            return this.descriptionField;
        }
        set
        {
            this.descriptionField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://purl.org/dc/elements/1.1/")]
    public System.DateTime date
    {
        get
        {
            return this.dateField;
        }
        set
        {
            this.dateField = value;
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
    public string about
    {
        get
        {
            return this.aboutField;
        }
        set
        {
            this.aboutField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#")]
[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#", IsNullable = false)]
public partial class Seq
{

    private SeqLI[] liField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("li")]
    public SeqLI[] li
    {
        get
        {
            return this.liField;
        }
        set
        {
            this.liField = value;
        }
    }
}

