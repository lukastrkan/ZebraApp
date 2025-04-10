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
    /// Spool
    /// </summary>
    [DataContract(Name = "Spool")]
    public partial class Spool : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Spool" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Spool() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Spool" /> class.
        /// </summary>
        /// <param name="id">Unique internal ID of this spool of filament. (required).</param>
        /// <param name="registered">When the spool was registered in the database. UTC Timezone. (required).</param>
        /// <param name="firstUsed">firstUsed.</param>
        /// <param name="lastUsed">lastUsed.</param>
        /// <param name="filament">The filament type of this spool. (required).</param>
        /// <param name="price">price.</param>
        /// <param name="remainingWeight">remainingWeight.</param>
        /// <param name="initialWeight">initialWeight.</param>
        /// <param name="spoolWeight">spoolWeight.</param>
        /// <param name="usedWeight">Consumed weight of filament from the spool in grams. (required).</param>
        /// <param name="remainingLength">remainingLength.</param>
        /// <param name="usedLength">Consumed length of filament from the spool in millimeters. (required).</param>
        /// <param name="location">location.</param>
        /// <param name="lotNr">lotNr.</param>
        /// <param name="comment">comment.</param>
        /// <param name="archived">Whether this spool is archived and should not be used anymore. (required).</param>
        /// <param name="extra">Extra fields for this spool. All values are JSON-encoded data. Query the /fields endpoint for more details about the fields. (required).</param>
        public Spool(int id = default(int), string registered = default(string), string firstUsed = default(string), string lastUsed = default(string), Filament filament = default(Filament), decimal? price = default(decimal?), decimal? remainingWeight = default(decimal?), decimal? initialWeight = default(decimal?), decimal? spoolWeight = default(decimal?), decimal usedWeight = default(decimal), decimal? remainingLength = default(decimal?), decimal usedLength = default(decimal), string location = default(string), string lotNr = default(string), string comment = default(string), bool archived = default(bool), Dictionary<string, string> extra = default(Dictionary<string, string>))
        {
            this.Id = id;
            // to ensure "registered" is required (not null)
            if (registered == null)
            {
                throw new ArgumentNullException("registered is a required property for Spool and cannot be null");
            }
            this.Registered = registered;
            // to ensure "filament" is required (not null)
            if (filament == null)
            {
                throw new ArgumentNullException("filament is a required property for Spool and cannot be null");
            }
            this.Filament = filament;
            this.UsedWeight = usedWeight;
            this.UsedLength = usedLength;
            this.Archived = archived;
            // to ensure "extra" is required (not null)
            if (extra == null)
            {
                throw new ArgumentNullException("extra is a required property for Spool and cannot be null");
            }
            this.Extra = extra;
            this.FirstUsed = firstUsed;
            this.LastUsed = lastUsed;
            this.Price = price;
            this.RemainingWeight = remainingWeight;
            this.InitialWeight = initialWeight;
            this.SpoolWeight = spoolWeight;
            this.RemainingLength = remainingLength;
            this.Location = location;
            this.LotNr = lotNr;
            this.Comment = comment;
        }

        /// <summary>
        /// Unique internal ID of this spool of filament.
        /// </summary>
        /// <value>Unique internal ID of this spool of filament.</value>
        [DataMember(Name = "id", IsRequired = true, EmitDefaultValue = true)]
        public int Id { get; set; }

        /// <summary>
        /// When the spool was registered in the database. UTC Timezone.
        /// </summary>
        /// <value>When the spool was registered in the database. UTC Timezone.</value>
        [DataMember(Name = "registered", IsRequired = true, EmitDefaultValue = true)]
        public string Registered { get; set; }

        /// <summary>
        /// Gets or Sets FirstUsed
        /// </summary>
        [DataMember(Name = "first_used", EmitDefaultValue = true)]
        public string FirstUsed { get; set; }

        /// <summary>
        /// Gets or Sets LastUsed
        /// </summary>
        [DataMember(Name = "last_used", EmitDefaultValue = true)]
        public string LastUsed { get; set; }

        /// <summary>
        /// The filament type of this spool.
        /// </summary>
        /// <value>The filament type of this spool.</value>
        [DataMember(Name = "filament", IsRequired = true, EmitDefaultValue = true)]
        public Filament Filament { get; set; }

        /// <summary>
        /// Gets or Sets Price
        /// </summary>
        [DataMember(Name = "price", EmitDefaultValue = true)]
        public decimal? Price { get; set; }

        /// <summary>
        /// Gets or Sets RemainingWeight
        /// </summary>
        [DataMember(Name = "remaining_weight", EmitDefaultValue = true)]
        public decimal? RemainingWeight { get; set; }

        /// <summary>
        /// Gets or Sets InitialWeight
        /// </summary>
        [DataMember(Name = "initial_weight", EmitDefaultValue = true)]
        public decimal? InitialWeight { get; set; }

        /// <summary>
        /// Gets or Sets SpoolWeight
        /// </summary>
        [DataMember(Name = "spool_weight", EmitDefaultValue = true)]
        public decimal? SpoolWeight { get; set; }

        /// <summary>
        /// Consumed weight of filament from the spool in grams.
        /// </summary>
        /// <value>Consumed weight of filament from the spool in grams.</value>
        [DataMember(Name = "used_weight", IsRequired = true, EmitDefaultValue = true)]
        public decimal UsedWeight { get; set; }

        /// <summary>
        /// Gets or Sets RemainingLength
        /// </summary>
        [DataMember(Name = "remaining_length", EmitDefaultValue = true)]
        public decimal? RemainingLength { get; set; }

        /// <summary>
        /// Consumed length of filament from the spool in millimeters.
        /// </summary>
        /// <value>Consumed length of filament from the spool in millimeters.</value>
        [DataMember(Name = "used_length", IsRequired = true, EmitDefaultValue = true)]
        public decimal UsedLength { get; set; }

        /// <summary>
        /// Gets or Sets Location
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = true)]
        public string Location { get; set; }

        /// <summary>
        /// Gets or Sets LotNr
        /// </summary>
        [DataMember(Name = "lot_nr", EmitDefaultValue = true)]
        public string LotNr { get; set; }

        /// <summary>
        /// Gets or Sets Comment
        /// </summary>
        [DataMember(Name = "comment", EmitDefaultValue = true)]
        public string Comment { get; set; }

        /// <summary>
        /// Whether this spool is archived and should not be used anymore.
        /// </summary>
        /// <value>Whether this spool is archived and should not be used anymore.</value>
        [DataMember(Name = "archived", IsRequired = true, EmitDefaultValue = true)]
        public bool Archived { get; set; }

        /// <summary>
        /// Extra fields for this spool. All values are JSON-encoded data. Query the /fields endpoint for more details about the fields.
        /// </summary>
        /// <value>Extra fields for this spool. All values are JSON-encoded data. Query the /fields endpoint for more details about the fields.</value>
        [DataMember(Name = "extra", IsRequired = true, EmitDefaultValue = true)]
        public Dictionary<string, string> Extra { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Spool {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Registered: ").Append(Registered).Append("\n");
            sb.Append("  FirstUsed: ").Append(FirstUsed).Append("\n");
            sb.Append("  LastUsed: ").Append(LastUsed).Append("\n");
            sb.Append("  Filament: ").Append(Filament).Append("\n");
            sb.Append("  Price: ").Append(Price).Append("\n");
            sb.Append("  RemainingWeight: ").Append(RemainingWeight).Append("\n");
            sb.Append("  InitialWeight: ").Append(InitialWeight).Append("\n");
            sb.Append("  SpoolWeight: ").Append(SpoolWeight).Append("\n");
            sb.Append("  UsedWeight: ").Append(UsedWeight).Append("\n");
            sb.Append("  RemainingLength: ").Append(RemainingLength).Append("\n");
            sb.Append("  UsedLength: ").Append(UsedLength).Append("\n");
            sb.Append("  Location: ").Append(Location).Append("\n");
            sb.Append("  LotNr: ").Append(LotNr).Append("\n");
            sb.Append("  Comment: ").Append(Comment).Append("\n");
            sb.Append("  Archived: ").Append(Archived).Append("\n");
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
            // Price (decimal?) minimum
            if (this.Price < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for Price, must be a value greater than or equal to 0.", new [] { "Price" });
            }

            // RemainingWeight (decimal?) minimum
            if (this.RemainingWeight < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for RemainingWeight, must be a value greater than or equal to 0.", new [] { "RemainingWeight" });
            }

            // InitialWeight (decimal?) minimum
            if (this.InitialWeight < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for InitialWeight, must be a value greater than or equal to 0.", new [] { "InitialWeight" });
            }

            // SpoolWeight (decimal?) minimum
            if (this.SpoolWeight < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for SpoolWeight, must be a value greater than or equal to 0.", new [] { "SpoolWeight" });
            }

            // UsedWeight (decimal) minimum
            if (this.UsedWeight < (decimal)0)
            {
                yield return new ValidationResult("Invalid value for UsedWeight, must be a value greater than or equal to 0.", new [] { "UsedWeight" });
            }

            // RemainingLength (decimal?) minimum
            if (this.RemainingLength < (decimal?)0)
            {
                yield return new ValidationResult("Invalid value for RemainingLength, must be a value greater than or equal to 0.", new [] { "RemainingLength" });
            }

            // UsedLength (decimal) minimum
            if (this.UsedLength < (decimal)0)
            {
                yield return new ValidationResult("Invalid value for UsedLength, must be a value greater than or equal to 0.", new [] { "UsedLength" });
            }

            // Location (string) maxLength
            if (this.Location != null && this.Location.Length > 64)
            {
                yield return new ValidationResult("Invalid value for Location, length must be less than 64.", new [] { "Location" });
            }

            // LotNr (string) maxLength
            if (this.LotNr != null && this.LotNr.Length > 64)
            {
                yield return new ValidationResult("Invalid value for LotNr, length must be less than 64.", new [] { "LotNr" });
            }

            // Comment (string) maxLength
            if (this.Comment != null && this.Comment.Length > 1024)
            {
                yield return new ValidationResult("Invalid value for Comment, length must be less than 1024.", new [] { "Comment" });
            }

            yield break;
        }
    }

}
