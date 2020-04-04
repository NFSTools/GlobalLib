namespace GlobalLib.Reflection.Abstract
{
    /// <summary>
    /// <see cref="Collectable"/> class is a default collection of properties and fields of any 
    /// global type, which information can be accessed and modified through those properties. 
    /// It inherits from <see cref="Primitive"/> class and <see cref="Interface.ICastable{TypeID}"/> 
    /// interface and implements/overrides most of their methods.
    /// </summary>
	public abstract class Collectable : Primitive, Interface.ICastable<Collectable>
	{
        /// <summary>
        /// Collection name of the variable.
        /// </summary>
        public abstract string CollectionName { get; set; }
        public virtual bool Deletable { get; set; } = true;
        public abstract Core.GameINT GameINT { get; }
        public abstract string GameSTR { get; }

        /// <summary>
        /// Returns array of all accessible and modifiable properties and fields.
        /// </summary>
        /// <returns>Array of strings.</returns>
        public override object[] GetAccessibles(Enum.eGetInfoType type)
        {
            var list = new System.Collections.Generic.List<object>();
            foreach (var property in this.GetType().GetProperties())
            {
                if (System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                {
                    if (type == Enum.eGetInfoType.PROPERTY_NAMES)
                        list.Add(property.Name);
                    else
                        list.Add(property);
                }
            }
            return list.ToArray();
        }

        public SubPart GetSubPart(string name, string node)
        {
            var property = this.GetType().GetProperty(name);
            if (property == null) return null;
            foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
            {
                var attrib = obj as Attributes.ExpandableAttribute;
                if (attrib.Name == node) return (SubPart)property.GetValue(this);
            }
            return null;
        }
        public bool GetSubPart(string name, string node, out SubPart part)
        {
            part = null;
            var property = this.GetType().GetProperty(name);
            if (property == null) return false;
            foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
            {
                var attrib = obj as Attributes.ExpandableAttribute;
                if (attrib.Name == node)
                {
                    part = (SubPart)property.GetValue(this);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Gets all nodes and subnodes from the class.
        /// </summary>
        /// <returns>Array of virtual nodes that can be used to build treeview.</returns>
        public virtual System.Collections.Generic.List<VirtualNode> GetAllNodes()
        {
            var list = new System.Collections.Generic.List<VirtualNode>();
            foreach (var property in this.GetType().GetProperties())
            {
                foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
                {
                    var attrib = obj as Attributes.ExpandableAttribute;
                    var node = list.Find(c => c.NodeName == attrib.Name);
                    if (node == null)
                    {
                        node = new VirtualNode(attrib.Name);
                        list.Add(node);
                    }
                    node.SubNodes.Add(new VirtualNode(property.Name));
                }
            }
            list.Sort((x, y) => x.NodeName.CompareTo(y.NodeName));
            return list;
        }

        public virtual object[] GetSubnodeAttribs(string NodeName, Enum.eGetInfoType type)
        {
            var property = this.GetType().GetProperty(NodeName);
            if (property == null) return null;
            var result = new System.Collections.Generic.List<object>();
            foreach (var field in property.PropertyType.GetProperties())
            {
                if (type == Enum.eGetInfoType.PROPERTY_NAMES)
                    result.Add(field.Name);
                else
                    result.Add(field);
            }
            return result.ToArray();
        }

        public virtual string GetValueOfInternalObject(string NodeName, string field)
        {
            var property = this.GetType().GetProperty(NodeName);
            if (property == null) return null;
            return !System.Attribute.IsDefined(property, typeof(Attributes.ExpandableAttribute))
                ? null
                : (string)property.PropertyType.GetMethod("GetValue")
                            .Invoke(property.GetValue(this), new object[1] { field });

        }

        /// <summary>
        /// Checks if this class contains property with name specified that has AccessModifiable attribute.
        /// </summary>
        /// <param name="PropertyName">Name of the property to check.</param>
        /// <returns>True if property exists and has AccessModifiable attribute; false otherwise.</returns>
        public virtual bool ContainsAccessModifiable(string PropertyName)
        {
            var property = this.GetType().GetProperty(PropertyName);
            if (property == null) return false;
            return System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute));
        }

        /// <summary>
        /// Sets value at a field of an internal object, if such exists.
        /// </summary>
        /// <param name="paths">Parameters of the path to object, including property name and value to set.</param>
        public virtual bool SetValueOfInternalObject(params string[] paths)
        {
            string subroute = paths[0];
            string nodename = paths[1];
            string propertyname = paths[2];
            string value = paths[3];

            var property = this.GetType().GetProperty(nodename);
            if (property == null) return false;
            foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
            {
                var attrib = obj as Attributes.ExpandableAttribute;
                if (attrib.Name == subroute)
                    goto LABEL_CHANGE_VAL;
            }
            return false;

        LABEL_CHANGE_VAL:
            if (!typeof(Interface.ISetValue).IsAssignableFrom(property.PropertyType))
                return false;
            var method = property.PropertyType.GetMethod("SetValue", System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance, null, System.Reflection.CallingConventions.Any,
                new System.Type[] { typeof(string), typeof(object) }, null);
            return (bool)method.Invoke(property.GetValue(this), new object[2] { propertyname, value });
        }

        /// <summary>
        /// Sets value at a field of an internal object, if such exists.
        /// </summary>
        /// <param name="paths">Parameters of the path to object, including property name and value to set.</param>
        public virtual bool SetValueOfInternalObject(ref string error, params string[] paths)
        {
            string subroute = paths[0];
            string nodename = paths[1];
            string propertyname = paths[2];
            string value = paths[3];

            var property = this.GetType().GetProperty(nodename);
            if (property == null)
            {
                error = $"Node named {nodename} could not be found.";
                return false;
            }
            foreach (var obj in property.GetCustomAttributes(typeof(Attributes.ExpandableAttribute), true))
            {
                var attrib = obj as Attributes.ExpandableAttribute;
                if (attrib.Name == subroute)
                    goto LABEL_CHANGE_VAL;
            }
            error = $"Subroute named {subroute} could not be found.";
            return false;

        LABEL_CHANGE_VAL:
            if (!typeof(Interface.ISetValue).IsAssignableFrom(property.PropertyType))
                return false;
            var method = property.PropertyType.GetMethod("SetValue", System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.Instance, null, System.Reflection.CallingConventions.Any,
                new System.Type[] { typeof(string), typeof(object), typeof(string).MakeByRefType() }, null);
            var objs = new object[3] { propertyname, value, null };
            var result = (bool)method.Invoke(property.GetValue(this), objs);
            if (objs[2] != null) error = objs[2].ToString();
            return result;
        }

        /// <summary>
        /// Returns the value of a field name provided.
        /// </summary>
        /// <param name="PropertyName">Field name to get the value from.</param>
        /// <returns>String value of a field name.</returns>
        public override string GetValue(string PropertyName)
        {
            var result = this.GetType().GetProperty(PropertyName);
            if (result == null) return null;
            else return result.GetValue(this).ToString();
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public override bool SetValue(string PropertyName, object value)
        {
            try
            {
                var property = this.GetType().GetProperty(PropertyName);
                if (property == null) return false;
                if (!System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    throw new System.FieldAccessException("This field is either non-modifiable or non-accessible");
                if (property.PropertyType.IsEnum)
                {
                    property.SetValue(this, System.Enum.Parse(property.PropertyType, value.ToString()));
                }
                else
                {
                    property.SetValue(this, typeof(Utils.Cast)
                        .GetMethod("RuntimeCast")
                        .Invoke(null, new object[] { value, property.PropertyType }));
                }
                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                if (Core.Process.MessageShow)
                    System.Windows.Forms.MessageBox.Show(e.Message);
                else
                    System.Console.WriteLine($"{e.Message}");
                return false;
            }
        }

        /// <summary>
        /// Sets value at a field specified.
        /// </summary>
        /// <param name="PropertyName">Name of the field to be modified.</param>
        /// <param name="value">Value to be set at the field specified.</param>
        public override bool SetValue(string PropertyName, object value, ref string error)
        {
            try
            {
                var property = this.GetType().GetProperty(PropertyName);
                if (property == null)
                {
                    error = $"Field named {PropertyName} does not exist.";
                    return false;
                }
                if (!System.Attribute.IsDefined(property, typeof(Attributes.AccessModifiableAttribute)))
                    throw new System.FieldAccessException("This field is either non-modifiable or non-accessible");
                var type = property.GetType();
                if (property.PropertyType.IsEnum)
                {
                    property.SetValue(this, System.Enum.Parse(property.PropertyType, value.ToString()));
                }
                else
                {
                    property.SetValue(this, typeof(Utils.Cast)
                        .GetMethod("RuntimeCast")
                        .Invoke(null, new object[] { value, property.PropertyType }));
                }
                return true;
            }
            catch (System.Exception e)
            {
                while (e.InnerException != null) e = e.InnerException;
                error = e.Message;
                return false;
            }
        }
    
        public virtual bool SetStaticValue(string PropertyName, object value)
        {
            return false;
        }

        public abstract Collectable MemoryCast(string CName);
    }
}