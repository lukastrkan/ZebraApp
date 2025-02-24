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
    /// SpoolMeasureParameters
    /// </summary>
    [DataContract(Name = "SpoolMeasureParameters")]
    public partial class SpoolMeasureParameters : IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpoolMeasureParameters" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected SpoolMeasureParameters() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="SpoolMeasureParameters" /> class.
        /// </summary>
        /// <param name="weight">Current gross weight of the spool, in g. (required).</param>
        public SpoolMeasureParameters(decimal weight = default(decimal))
        {
            this.Weight = weight;
        }

        /// <summary>
        /// Current gross weight of the spool, in g.
        /// </summary>
        /// <value>Current gross weight of the spool, in g.</value>
        [DataMember(Name = "weight", IsRequired = true, EmitDefaultValue = true)]
        public decimal Weight { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class SpoolMeasureParameters {\n");
            sb.Append("  Weight: ").Append(Weight).Append("\n");
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
            yield break;
        }
    }

}
