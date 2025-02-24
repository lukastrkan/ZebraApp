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
    /// Filament
    /// </summary>
    [DataContract(Name = "Filament")]
    public partial class Filament : IValidatableObject
    {

        /// <summary>
        /// Gets or Sets MultiColorDirection
        /// </summary>
        [DataMember(Name = "multi_color_direction", EmitDefaultValue = true)]
        public SpoolmanApiV1ModelsMultiColorDirection? MultiColorDirection { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Filament" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Filament() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Filament" /> class.
        /// </summary>
        /// <param name="id">Unique internal ID of this filament type. (required).</param>
        /// <param name="registered">When the filament was registered in the database. UTC Timezone. (required).</param>
        /// <param name="name">name.</param>
        /// <param name="vendor">vendor.</param>
        /// <param name="material">material.</param>
        /// <param name="price">price.</param>
        /// <param name="density">The density of this filament in g/cm3. (required).</param>
        /// <param name="diameter">The diameter of this filament in mm. (required).</param>
        /// <param name="weight">weight.</param>
        /// <param name="spoolWeight">spoolWeight.</param>
        /// <param name="articleNumber">articleNumber.</param>
        /// <param name="comment">comment.</param>
        /// <param name="settingsExtruderTemp">settingsExtruderTemp.</param>
        /// <param name="settingsBedTemp">settingsBedTemp.</param>
        /// <param name="colorHex">colorHex.</param>
        /// <param name="multiColorHexes">multiColorHexes.</param>
        /// <param name="multiColorDirection">multiColorDirection.</param>
        /// <param name="externalId">externalId.</param>
        /// <param name="extra">Extra fields for this filament. All values are JSON-encoded data. Query the /fields endpoint for more details about the fields. (required).</param>
        public Filament(int id = default(int), string registered = default(string), string name = default(string), Vendor vendor = default(Vendor), string material = default(string), decimal? price = default(decimal?), decimal density = default(decimal), decimal diameter = default(decimal), decimal? weight = default(decimal?), decimal? spoolWeight = default(decimal?), string articleNumber = default(string), string comment = default(string), int? settingsExtruderTemp = default(int?), int? settingsBedTemp = default(int?), string colorHex = default(string), string multiColorHexes = default(string), SpoolmanApiV1ModelsMultiColorDirection? multiColorDirection = default(SpoolmanApiV1ModelsMultiColorDirection?), string externalId = default(string), Dictionary<string, string> extra = default(Dictionary<string, string>))
        {
            this.Id = id;
            // to ensure "registered" is required (not null)
            if (registered == null)
            {
                throw new ArgumentNullException("registered is a required property for Filament and cannot be null");
            }
            this.Registered = registered;
            this.Density = density;
            this.Diameter = diameter;
            // to ensure "extra" is required (not null)
            if (extra == null)
            {
                throw new ArgumentNullException("extra is a required property for Filament and cannot be null");
            }
            this.Extra = extra;
            this.Name = name;
            this.Vendor = vendor;
            this.Material = material;
            this.Price = price;
            this.Weight = weight;
            this.SpoolWeight = spoolWeight;
            this.ArticleNumber = articleNumber;
            this.Comment = comment;
            this.SettingsExtruderTemp = settingsExtruderTemp;
            this.SettingsBedTemp = settingsBedTemp;
            this.ColorHex = colorHex;
            this.MultiColorHexes = multiColorHexes;
            this.MultiColorDirection = multiColorDirection;
            this.ExternalId = externalId;
        }

        /// <summary>
        /// Unique internal ID of this filament type.
        /// </summary>
        /// <value>Unique internal ID of this filament type.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public int Id { get; set; }

        /// <summary>
        /// When the filament was registered in the database. UTC Timezone.
        /// </summary>
        /// <value>When the filament was registered in the database. UTC Timezone.</value>
        [DataMember(Name = "registered", IsRequired = true, EmitDefaultValue = true)]
        public string Registered { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Vendor
        /// </summary>
        [DataMember(Name = "vendor", EmitDefaultValue = true)]
        public Vendor Vendor { get; set; }

        /// <summary>
        /// Gets or Sets Material
        /// </summary>
        [DataMember(Name = "material", EmitDefaultValue = true)]
        public string Material { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = true)]
        public decimal? Price { get; set; }

        /// <summary>
        /// The density of this filament in g/cm3.
        /// </summary>
        /// <value>The density of this filament in g/cm3.</value>
        [DataMember(Name = "density", IsRequired = true, EmitDefaultValue = true)]
        public decimal Density { get; set; }

        /// <summary>
        /// The diameter of this filament in mm.
        /// </summary>
        /// <value>The diameter of this filament in mm.</value>
        [DataMember(Name = "diameter", IsRequired = true, EmitDefaultValue = true)]
        public decimal Diameter { get; set; }

        /// <summary>
        /// Gets or Sets Weight
        /// </summary>
        [DataMember(Name = "weight", EmitDefaultValue = true)]
        public decimal? Weight { get; set; }

        /// <summary>
        /// Gets or Sets SpoolWeight
        /// </summary>
        [DataMember(Name = "spool_weight", EmitDefaultValue = true)]
        public decimal? SpoolWeight { get; set; }

        /// <summary>
        /// Gets or Sets ArticleNumber
        /// </summary>
        [DataMember(Name = "article_number", EmitDefaultValue = true)]
        public string ArticleNumber { get; set; }

        /// <summary>
        /// Gets or Sets Comment
        /// </summary>
        [DataMember(Name = "comment", EmitDefaultValue = true)]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or Sets SettingsExtruderTemp
        /// </summary>
        [DataMember(Name = "settings_extruder_temp", EmitDefaultValue = true)]
        public int? SettingsExtruderTemp { get; set; }

        /// <summary>
        /// Gets or Sets SettingsBedTemp
        /// </summary>
        [DataMember(Name = "settings_bed_temp", EmitDefaultValue = true)]
        public int? SettingsBedTemp { get; set; }

        /// <summary>
        /// Gets or Sets ColorHex
        /// </summary>
        [DataMember(Name = "color_hex", EmitDefaultValue = true)]
        public string ColorHex { get; set; }

        /// <summary>
        /// Gets or Sets MultiColorHexes
        /// </summary>
        [DataMember(Name = "multi_color_hexes", EmitDefaultValue = true)]
        public string MultiColorHexes { get; set; }

        /// <summary>
        /// Gets or Sets ExternalId
        /// </summary>
        [DataMember(Name = "external_id", EmitDefaultValue = true)]
        public string ExternalId { get; set; }

        /// <summary>
        /// Extra fields for this filament. All values are JSON-encoded data. Query the /fields endpoint for more details about the fields.
        /// </summary>
        /// <value>Extra fields for this filament. All values are JSON-encoded data. Query the /fields endpoint for more details about the fields.</value>
        [DataMember(Name = "extra", IsRequired = true, EmitDefaultValue = true)]
        public Dictionary<string, string> Extra { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Filament {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Registered: ").Append(Registered).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
            sb.Append("  Material: ").Append(Material).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  Density: ").Append(Density).Append("\n");
            sb.Append("  Diameter: ").Append(Diameter).Append("\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
            sb.Append("  SpoolWeight: ").Append(SpoolWeight).Append("\n");
            sb.Append("  ArticleNumber: ").Append(ArticleNumber).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  SettingsExtruderTemp: ").Append(SettingsExtruderTemp).Append("\n");
            sb.Append("  SettingsBedTemp: ").Append(SettingsBedTemp).Append("\n");
            sb.Append("  ColorHex: ").Append(ColorHex).Append("\n");
            sb.Append("  MultiColorHexes: ").Append(MultiColorHexes).Append("\n");
            sb.Append("  MultiColorDirection: ").Append(MultiColorDirection).Append("\n");
            sb.Append("  ExternalId: ").Append(ExternalId).Append("\n");
            sb.Append("  Extra: ").Append(Extra).Append("\n");
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
            if (this.Name != null && this.Name.Length > 64)
            {
                yield return new ValidationResult("Invalid value for Name, length must be less than 64.", new [] { "Name" });
            }

            // Material (string) maxLength
            if (this.Material != null && this.Material.Length > 64)
            {
                yield return new ValidationResult("Invalid value for Material, length must be less than 64.", new [] { "Material" });
            }

            // Price (decimal?) minimum
            if (this.Price < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for Price, must be a value greater than or equal to 0.", new [] { "Price" });
            }

            // SpoolWeight (decimal?) minimum
            if (this.SpoolWeight < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for SpoolWeight, must be a value greater than or equal to 0.", new [] { "SpoolWeight" });
            }

            // ArticleNumber (string) maxLength
            if (this.ArticleNumber != null && this.ArticleNumber.Length > 64)
            {
                yield return new ValidationResult("Invalid value for ArticleNumber, length must be less than 64.", new [] { "ArticleNumber" });
            }

            // Comment (string) maxLength
            if (this.Comment != null && this.Comment.Length > 1024)
            {
                yield return new ValidationResult("Invalid value for Comment, length must be less than 1024.", new [] { "Comment" });
            }

            // SettingsExtruderTemp (int?) minimum
            if (this.SettingsExtruderTemp < (int?)0)
            {
                yield return new ValidationResult("Invalid value for SettingsExtruderTemp, must be a value greater than or equal to 0.", new [] { "SettingsExtruderTemp" });
            }

            // SettingsBedTemp (int?) minimum
            if (this.SettingsBedTemp < (int?)0)
            {
                yield return new ValidationResult("Invalid value for SettingsBedTemp, must be a value greater than or equal to 0.", new [] { "SettingsBedTemp" });
            }

            // ColorHex (string) maxLength
            if (this.ColorHex != null && this.ColorHex.Length > 8)
            {
                yield return new ValidationResult("Invalid value for ColorHex, length must be less than 8.", new [] { "ColorHex" });
            }

            // ColorHex (string) minLength
            if (this.ColorHex != null && this.ColorHex.Length < 6)
            {
                yield return new ValidationResult("Invalid value for ColorHex, length must be greater than 6.", new [] { "ColorHex" });
            }

            // MultiColorHexes (string) minLength
            if (this.MultiColorHexes != null && this.MultiColorHexes.Length < 6)
            {
                yield return new ValidationResult("Invalid value for MultiColorHexes, length must be greater than 6.", new [] { "MultiColorHexes" });
            }

            // ExternalId (string) maxLength
            if (this.ExternalId != null && this.ExternalId.Length > 256)
            {
                yield return new ValidationResult("Invalid value for ExternalId, length must be less than 256.", new [] { "ExternalId" });
            }

            yield break;
        }
    }

}
