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
    /// Defines Finish
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Finish
    {
        /// <summary>
        /// Enum Matte for value: matte
        /// </summary>
        [EnumMember(Value = "matte")]
        Matte = 1,

        /// <summary>
        /// Enum Glossy for value: glossy
        /// </summary>
        [EnumMember(Value = "glossy")]
        Glossy = 2
    }

}
