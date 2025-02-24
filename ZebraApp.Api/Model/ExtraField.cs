/*
 * Spoolman REST API v1
 *
 *      REST API for Spoolman.      The API is served on the path `/api/v1/`.      Some endpoints also serve a websocket on the same path. The websocket is used to listen for changes to the data     that the endpoint serves. The websocket messages are JSON objects. Additionally, there is a root-level websocket     endpoint that listens for changes to any data in the database.     
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = ZebraApp.Api.Client.OpenAPIDateConverter;

namespace ZebraApp.Api.Model
{
    /// <summary>
    /// ExtraField
    /// </summary>
    [DataContract(Name = "ExtraField")]
    public partial class ExtraField : IValidatableObject
    {

        /// <summary>
        /// Type of the field
        /// </summary>
        /// <value>Type of the field</value>
        [DataMember(Name = "field_type", IsRequired = true, EmitDefaultValue = true)]
        public ExtraFieldType FieldType { get; set; }

        /// <summary>
        /// Entity type this field is for
        /// </summary>
        /// <value>Entity type this field is for</value>
        [DataMember(Name = "entity_type", IsRequired = true, EmitDefaultValue = true)]
        public EntityType EntityType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraField" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ExtraField() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtraField" /> class.
        /// </summary>
        /// <param name="name">Nice name (required).</param>
        /// <param name="order">Order of the field (default to 0).</param>
        /// <param name="unit">unit.</param>
        /// <param name="fieldType">Type of the field (required).</param>
        /// <param name="defaultValue">defaultValue.</param>
        /// <param name="choices">choices.</param>
        /// <param name="multiChoice">multiChoice.</param>
        /// <param name="key">Unique key (required).</param>
        /// <param name="entityType">Entity type this field is for (required).</param>
        public ExtraField(string name = default(string), int order = 0, string unit = default(string), ExtraFieldType fieldType = default(ExtraFieldType), string defaultValue = default(string), List<string> choices = default(List<string>), bool? multiChoice = default(bool?), string key = default(string), EntityType entityType = default(EntityType))
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new ArgumentNullException("name is a required property for ExtraField and cannot be null");
            }
            this.Name = name;
            this.FieldType = fieldType;
            // to ensure "key" is required (not null)
            if (key == null)
            {
                throw new ArgumentNullException("key is a required property for ExtraField and cannot be null");
            }
            this.Key = key;
            this.EntityType = entityType;
            this.Order = order;
            this.Unit = unit;
            this.DefaultValue = defaultValue;
            this.Choices = choices;
            this.MultiChoice = multiChoice;
        }

        /// <summary>
        /// Nice name
        /// </summary>
        /// <value>Nice name</value>
        [DataMember(Name = "name", IsRequired = true, EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Order of the field
        /// </summary>
        /// <value>Order of the field</value>
        [DataMember(Name = "order", EmitDefaultValue = false)]
        public int Order { get; set; }

        /// <summary>
        /// Gets or Sets Unit
        /// </summary>
        [DataMember(Name = "unit", EmitDefaultValue = true)]
        public string Unit { get; set; }

        /// <summary>
        /// Gets or Sets DefaultValue
        /// </summary>
        [DataMember(Name = "default_value", EmitDefaultValue = true)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Gets or Sets Choices
        /// </summary>
        [DataMember(Name = "choices", EmitDefaultValue = true)]
        public List<string> Choices { get; set; }

        /// <summary>
        /// Gets or Sets MultiChoice
        /// </summary>
        [DataMember(Name = "multi_choice", EmitDefaultValue = true)]
        public bool? MultiChoice { get; set; }

        /// <summary>
        /// Unique key
        /// </summary>
        /// <value>Unique key</value>
        [DataMember(Name = "key", IsRequired = true, EmitDefaultValue = true)]
        public string Key { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class ExtraField {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Order: ").Append(Order).Append("\n");
            sb.Append("  Unit: ").Append(Unit).Append("\n");
            sb.Append("  FieldType: ").Append(FieldType).Append("\n");
            sb.Append("  DefaultValue: ").Append(DefaultValue).Append("\n");
            sb.Append("  Choices: ").Append(Choices).Append("\n");
            sb.Append("  MultiChoice: ").Append(MultiChoice).Append("\n");
            sb.Append("  Key: ").Append(Key).Append("\n");
            sb.Append("  EntityType: ").Append(EntityType).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // Name (string) maxLength
            if (this.Name != null && this.Name.Length > 128)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 128.", new [] { "Name" });
            }

            // Name (string) minLength
            if (this.Name != null && this.Name.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Name, length must be greater than 1.", new [] { "Name" });
            }

            // Unit (string) maxLength
            if (this.Unit != null && this.Unit.Length > 16)
            {
                yield return new ValidationResult("Invalid value for Unit, length must be less than 16.", new [] { "Unit" });
            }

            // Unit (string) minLength
            if (this.Unit != null && this.Unit.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Unit, length must be greater than 1.", new [] { "Unit" });
            }

            // Key (string) maxLength
            if (this.Key != null && this.Key.Length > 64)
            {
                yield return new ValidationResult("Invalid value for Key, length must be less than 64.", new [] { "Key" });
            }

            // Key (string) minLength
            if (this.Key != null && this.Key.Length < 1)
            {
                yield return new ValidationResult("Invalid value for Key, length must be greater than 1.", new [] { "Key" });
            }

            if (this.Key != null) {
                // Key (string) pattern
                Regex regexKey = new Regex(@"^[a-z0-9_]+$", RegexOptions.CultureInvariant);
                if (!regexKey.Match(this.Key).Success)
                {
                    yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Key, must match a pattern of " + regexKey, new [] { "Key" });
                }
            }

            yield break;
        }
    }

}
