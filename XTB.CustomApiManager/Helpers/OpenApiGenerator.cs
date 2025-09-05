using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using YamlDotNet.Serialization;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Proxy;



namespace XTB.CustomApiManager.Helpers
{
    // OpenAPI Model Classes
    public class OpenApiDocument
    {
        [JsonProperty("openapi")]
        [YamlMember(Alias = "openapi")]
        public string OpenApi { get; set; }

        [JsonProperty("info")]
        [YamlMember(Alias = "info")]
        public OpenApiInfo Info { get; set; }

        [JsonProperty("servers")]
        [YamlMember(Alias = "servers")]
        public OpenApiServer[] Servers { get; set; }

        [JsonProperty("paths")]
        [YamlMember(Alias = "paths")]
        public Dictionary<string, OpenApiPathItem> Paths { get; set; } // Changed from Dictionary<string, object>

        [JsonProperty("components")]
        [YamlMember(Alias = "components")]
        public OpenApiComponents Components { get; set; }

        //[JsonProperty("security")]
        //[YamlMember(Alias = "security")]
        //public OpenApiSecurityRequirement[] Security { get; set; } // Changed back to array
    }

    public class OpenApiInfo
    {
        [JsonProperty("title")]
        [YamlMember(Alias = "title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        [JsonProperty("version")]
        [YamlMember(Alias = "version")]
        public string Version { get; set; }
    }

    public class OpenApiServer
    {
        [JsonProperty("url")]
        [YamlMember(Alias = "url")]
        public string Url { get; set; }
    }

    public class OpenApiComponents
    {
        [JsonProperty("schemas")]
        [YamlMember(Alias = "schemas")]
        public Dictionary<string, object> Schemas { get; set; }

        //[JsonProperty("securitySchemes")]
        //[YamlMember(Alias = "securitySchemes")]
        //public Dictionary<string, OpenApiSecurityScheme> SecuritySchemes { get; set; }
    }


    public class OpenApiPathItem
    {
        [JsonProperty("get", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "get")]
        public OpenApiOperation Get { get; set; }

        [JsonProperty("post", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "post")]
        public OpenApiOperation Post { get; set; }

        [JsonProperty("put", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "put")]
        public OpenApiOperation Put { get; set; }

        [JsonProperty("delete", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "delete")]
        public OpenApiOperation Delete { get; set; }

        [JsonProperty("patch", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "patch")]
        public OpenApiOperation Patch { get; set; }
    }

    public class OpenApiOperation
    {
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "tags")]
        public string[] Tags { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "summary")]
        public string Summary { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        [JsonProperty("operationId", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "operationId")]
        public string OperationId { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "parameters")]
        public OpenApiParameter[] Parameters { get; set; }

        [JsonProperty("requestBody", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "requestBody")]
        public OpenApiRequestBody RequestBody { get; set; }

        [JsonProperty("responses")]
        [YamlMember(Alias = "responses")]
        public OpenApiResponses Responses { get; set; }
    }

    public class OpenApiRequestBody
    {
        [JsonProperty("required")]
        [YamlMember(Alias = "required")]
        public bool Required { get; set; }

        [JsonProperty("content")]
        [YamlMember(Alias = "content")]
        public Dictionary<string, OpenApiMediaType> Content { get; set; }
    }

    public class OpenApiMediaType
    {
        [JsonProperty("schema")]
        [YamlMember(Alias = "schema")]
        public OpenApiSchema Schema { get; set; }
    }


    public class OpenApiSchema
    {
        
        [JsonProperty(@"$ref", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "$ref")]
        public string Ref { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "type")]
        public string Type { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "properties")]
        public Dictionary<string, OpenApiSchema> Properties { get; set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "required")]
        public string[] Required { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "format")]
        public string Format { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "pattern")]
        public string Pattern { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "items")]
        public OpenApiSchema Items { get; set; }

        [JsonProperty("maximum", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "maximum")]
        public int? Maximum { get; internal set; }


        [JsonProperty("minimum", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "minimum")]
        public int? Minimum { get; internal set; }
    }

    public class OpenApiParameter
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "name")]
        public string Name { get; set; }

        [JsonProperty("in", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "in")]
        public string In { get; set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "required")]
        public bool Required { get; set; }

        [JsonProperty("schema", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "schema")]
        public OpenApiSchema Schema { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        [JsonProperty("x-ms-docs-key-type", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "x-ms-docs-key-type")]
        public string XMsDocsKeyType { get; set; }
    }

    public class OpenApiSecurityScheme
    {
        [JsonProperty("type")]
        [YamlMember(Alias = "type")]
        public string Type { get; set; }

        [JsonProperty("flows")]
        [YamlMember(Alias = "flows")]
        public OpenApiOAuthFlows Flows { get; set; }

        [JsonProperty("description")]
        [YamlMember(Alias = "description")]
        public string Description { get; set; }
    }

    public class OpenApiOAuthFlows
    {
        [JsonProperty("authorizationCode")]
        [YamlMember(Alias = "authorizationCode")]
        public OpenApiOAuthFlow AuthorizationCode { get; set; }

        [JsonProperty("clientCredentials")]
        [YamlMember(Alias = "clientCredentials")]
        public OpenApiOAuthFlow ClientCredentials { get; set; }
    }

    public class OpenApiOAuthFlow
    {
        [JsonProperty("authorizationUrl", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "authorizationUrl")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("tokenUrl", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "tokenUrl")]
        public string TokenUrl { get; set; }

        [JsonProperty("scopes", NullValueHandling = NullValueHandling.Ignore)]
        [YamlMember(Alias = "scopes")]
        public Dictionary<string, string> Scopes { get; set; }
    }

    public class OpenApiSecurityRequirement : Dictionary<string, string[]>
    {
        // This class now inherits from Dictionary directly
        // Remove the Requirements property as it's not needed
    }

    public class OpenApiResponses
    {
        [JsonProperty("200")]
        [YamlMember(Alias = "200")]
        public OpenApiResponse Success { get; set; }

        [JsonProperty("400")]
        [YamlMember(Alias = "400")]
        public OpenApiResponse BadRequest { get; set; }

        [JsonProperty("401")]
        [YamlMember(Alias = "401")]
        public OpenApiResponse Unauthorized { get; set; }

        [JsonProperty("500")]
        [YamlMember(Alias = "500")]
        public OpenApiResponse InternalServerError { get; set; }
    }

    public class OpenApiResponse
    {
        [JsonProperty("description")]
        [YamlMember(Alias = "description")]
        public string Description { get; set; }

        [JsonProperty("content")]
        [YamlMember(Alias = "content")]
        public Dictionary<string, OpenApiMediaType> Content { get; set; }
    }

    public static class OpenApiGenerator
    {
        public static string GenerateOpenApiJson(CustomApiProxy customApi, List<CustomApiRequestParameterProxy> requestParameters, List<CustomApiResponsePropertyProxy> responseProperties, string baseUrl, string tenantId, string boundEntitySetName)
        {
            var openapi = OpenApiDocumentFor(customApi, requestParameters, responseProperties, baseUrl, tenantId, boundEntitySetName);

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(openapi, settings);
        }

        public static string GenerateOpenApiYaml(CustomApiProxy customApi, List<CustomApiRequestParameterProxy> requestParameters, List<CustomApiResponsePropertyProxy> responseProperties, string baseUrl, string tenantId, string boundEntitySetName)
        {
            var openapi = OpenApiDocumentFor(customApi, requestParameters, responseProperties, baseUrl, tenantId, boundEntitySetName);

            // OPTION 1: Current manual YAML generation (keep as fallback)
            //return ConvertToYaml(openapi);

            // OPTION 2: YamlDotNet implementation (uncomment when ready)
            return ConvertToYamlWithYamlDotNet(openapi);
        }


        // YamlDotNet Implementation - COMMENTED OUT FOR NOW
        private static string ConvertToYamlWithYamlDotNet(OpenApiDocument document)
        {
            var serializer = new SerializerBuilder()
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
                .Build();

            return serializer.Serialize(document);
        }


        private static OpenApiDocument OpenApiDocumentFor(CustomApiProxy customApi, List<CustomApiRequestParameterProxy> requestParameters, List<CustomApiResponsePropertyProxy> responseProperties, string baseUrl, string tenantId, string boundEntitySetName)
        {
            // Extract environment host for the security scope
            var uri = new Uri(baseUrl);
            var environmentHost = uri.Host;

            return new OpenApiDocument
            {
                OpenApi = "3.0.0",
                Info = new OpenApiInfo
                {
                    Title = customApi.DisplayName ?? customApi.Name,
                    Description = customApi.Description,
                    Version = "1.0.0"
                },
                Servers = new[]
                {
                    new OpenApiServer { Url = baseUrl }
                },
                Paths = GeneratePaths(customApi, requestParameters, responseProperties, boundEntitySetName),
                Components = new OpenApiComponents
                {
                    Schemas = GenerateComponentsSchemas(customApi, requestParameters, responseProperties),
                    //SecuritySchemes = GenerateSecuritySchemes(tenantId, baseUrl)
                },
                //Security = new[]
                //{
                //    new OpenApiSecurityRequirement
                //    {
                //        ["azuread"] = new string[] { $"https://{environmentHost}/.default" }
                //    }
                //}
            };
         }

        private static Dictionary<string, OpenApiPathItem> GeneratePaths(CustomApiProxy customApi, List<CustomApiRequestParameterProxy> requestParameters, List<CustomApiResponsePropertyProxy> responseProperties, string boundEntitySetName)
        {
            var paths = new Dictionary<string, OpenApiPathItem>();

            // Generate the API path
            string apiPath = $"/api/data/v9.2/{customApi.UniqueName}";
            if (customApi.BindingType == CustomAPI.BindingType_OptionSet.Entity)
            {
                apiPath = $"/api/data/v9.2/{boundEntitySetName}({{{customApi.BoundEntityLogicalName}id}})/Microsoft.Dynamics.CRM.{customApi.UniqueName}";
            }

            var operation = new OpenApiOperation
            {
                Tags = new[] { customApi.UniqueName },
                Summary = customApi.DisplayName,
                Description = customApi.Description,
                OperationId = customApi.UniqueName,
                Parameters = GenerateParameters(customApi, requestParameters),
                RequestBody = !customApi.IsFunction ? GenerateRequestBody(requestParameters) : null,
                Responses = GenerateResponses(responseProperties)
            };

            var pathItem = new OpenApiPathItem();

            // Set the appropriate HTTP method based on whether it's a function or action
            if (customApi.IsFunction)
            {
                pathItem.Get = operation;
            }
            else
            {
                pathItem.Post = operation;
            }

            paths[apiPath] = pathItem;
            return paths;
        }

        private static OpenApiParameter[] GenerateParameters(CustomApiProxy customApi, List<CustomApiRequestParameterProxy> requestParameters)
        {
            var parameters = new List<OpenApiParameter>();

            // Add entity ID parameter for bound APIs
            if (customApi.BindingType == CustomAPI.BindingType_OptionSet.Entity)
            {
                parameters.Add(new OpenApiParameter
                {
                    Name = $"{customApi.BoundEntityLogicalName}id",
                    In = "path",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        //Type = "string",
                        //Format = "uuid",
                        //Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$",
                        Ref = "#/components/schemas/Uuid" 
                    },
                    Description = $"key: {customApi.BoundEntityLogicalName}id",
                    XMsDocsKeyType = customApi.BoundEntityLogicalName

                });
            }

            // Add query parameters for functions
            if (customApi.IsFunction)
            {
                foreach (var param in requestParameters)
                {
                    parameters.Add(new OpenApiParameter
                    {
                        Name = param.UniqueName,
                        In = "query",
                        Required = !param.IsOptional,
                        Schema = GetSchemaForType(param),
                        Description = param.Description
                    });
                }
            }

            return parameters.ToArray();
        }

        private static OpenApiRequestBody GenerateRequestBody(List<CustomApiRequestParameterProxy> requestParameters)
        {
            if (requestParameters.Count == 0)
                return null;

            var properties = new Dictionary<string, OpenApiSchema>();
            var required = new List<string>();

            foreach (var param in requestParameters)
            {
                var property = CreatePropertyForType(param);

                properties[param.UniqueName] = property;

                if (!param.IsOptional)
                    required.Add(param.UniqueName);
            }

            return new OpenApiRequestBody
            {
                Required = true,
                Content = new Dictionary<string, OpenApiMediaType>
                {
                    ["application/json"] = new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Type = "object",
                            Properties = properties,
                            Required = required.ToArray()
                        }
                    }
                }
            };
        }

        private static OpenApiResponses GenerateResponses(List<CustomApiResponsePropertyProxy> responseProperties)
        {
            var responses = new OpenApiResponses
            {
                BadRequest = new OpenApiResponse { Description = "Bad Request" },
                Unauthorized = new OpenApiResponse { Description = "Unauthorized" },
                InternalServerError = new OpenApiResponse { Description = "Internal Server Error" }
            };

            if (responseProperties.Count > 0)
            {
                var properties = new Dictionary<string, OpenApiSchema>();
                foreach (var responseProperty in responseProperties)
                {

                    var property = CreatePropertyForResponseType(responseProperty);

                    properties[responseProperty.UniqueName] = property;
                }

                responses.Success = new OpenApiResponse
                {
                    Description = "Success",
                    Content = new Dictionary<string, OpenApiMediaType>
                    {
                        ["application/json"] = new OpenApiMediaType
                        {
                            Schema = new OpenApiSchema
                            {
                                Type = "object",
                                Properties = properties
                            }
                        }
                    }
                };
            }
            else
            {
                responses.Success = new OpenApiResponse
                {
                    Description = "Success"
                };
            }

            return responses;
        }

        private static Dictionary<string, object> GenerateComponentsSchemas(CustomApiProxy customApi, List<CustomApiRequestParameterProxy> requestParameters, List<CustomApiResponsePropertyProxy> responseProperties)
        {
            var schemas = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(customApi.BoundEntityLogicalName)) 
            {
                AddGuidSchema(schemas);
            }


            //request params
            foreach (var param in requestParameters)
            {
                switch (param.Type)
                {
                    case CustomAPIRequestParameter.Type_OptionSet.Guid:

                        AddGuidSchema(schemas);

                        break;

                    case CustomAPIRequestParameter.Type_OptionSet.DateTime:
                        AddDateTimeSchema(schemas);
                        break;

                    case CustomAPIRequestParameter.Type_OptionSet.Integer:
                    case CustomAPIRequestParameter.Type_OptionSet.Picklist:
                        AddIntSchema(schemas);
                        break;

                    case CustomAPIRequestParameter.Type_OptionSet.EntityReference:

                        AddEntityReferenceSchema(schemas, param.BoundEntityLogicalName);
                        AddGuidSchema(schemas);
                        break;

                        // TODO EntityList
                }
            }


            // response properties
            foreach (var property in responseProperties)
            {
                switch (property.Type)
                {
                    case CustomAPIResponseProperty.Type_OptionSet.Guid:

                        AddGuidSchema(schemas);

                        break;

                    case CustomAPIResponseProperty.Type_OptionSet.DateTime:
                        AddDateTimeSchema(schemas);
                        break;

                    case CustomAPIResponseProperty.Type_OptionSet.Integer:
                    case CustomAPIResponseProperty.Type_OptionSet.Picklist:
                        AddIntSchema(schemas);
                        break;

                    case CustomAPIResponseProperty.Type_OptionSet.EntityReference:

                        AddEntityReferenceSchema(schemas, property.BoundEntityLogicalName);
                        AddGuidSchema(schemas);
                        break;

                        // TODO EntityList
                }
            }


            return schemas;
        }

        private static void AddGuidSchema(Dictionary<string, object> schemas)
        {
            if (!schemas.ContainsKey($"Uuid"))
            {
                schemas[$"Uuid"] = new OpenApiSchema
                {
                    Type = "string",
                    Format = "uuid",
                    Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$",
                };
            }
        }

        private static void AddIntSchema(Dictionary<string, object> schemas)
        {
            if (!schemas.ContainsKey($"Int32"))
            {
                schemas[$"Int32"] = new OpenApiSchema
                {
                    Type = "integer",
                    Format = "int32",
                    Maximum = 2147483647,
                    Minimum = -2147483648
                };
            }
        }

        private static void AddDateTimeSchema(Dictionary<string, object> schemas)
        {
            if (!schemas.ContainsKey($"DateTime"))
            {
                schemas[$"DateTime"] = new OpenApiSchema
                {
                    Type = "string",
                    Format = "date-time",
                    Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$"
                };
            }
        }

        private static void AddEntityReferenceSchema(Dictionary<string, object> schemas, string entityName)
        {

            if (!schemas.ContainsKey($"Microsoft.Dynamics.CRM.{entityName}"))
            {
                schemas[$"Microsoft.Dynamics.CRM.{entityName}"] = new OpenApiSchema
                {
                    Type = "object",
                    Properties = new Dictionary<string, OpenApiSchema>
                    {
                        ["@odata.type"] = new OpenApiSchema
                        {
                            Type = "string",
                            Description = $"The OData type identifier for {entityName} entity",
                            Pattern = $@"^Microsoft\.Dynamics\.CRM\.{entityName}$"
                        },
                        [$"{entityName}id"] = new OpenApiSchema
                        {
                            //Type = "string",
                            //Format = "uuid",
                            //Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$",
                            Ref = "#/components/schemas/Uuid",
                            Description = $"The unique identifier of the {entityName}"
                        }
                    },
                    Required = new[] { "@odata.type", $"{entityName}id" }
                };
            }
        }

        private static OpenApiSchema GetSchemaForType(CustomApiRequestParameterProxy param)
        {
            var schema = new OpenApiSchema();

            switch (param.Type)
            {
                case CustomAPIRequestParameter.Type_OptionSet.Boolean:
                    schema.Type = "boolean";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.DateTime:
                    //schema.Type = "string";
                    //schema.Format = "date-time";
                    //schema.Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$";
                    schema.Ref = $"#/components/schemas/DateTime";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Decimal:
                    schema.Type = "number";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Entity:
                    schema.Type = "object";

                    break;

                case CustomAPIRequestParameter.Type_OptionSet.EntityCollection:
                    schema.Type = "array";
                    schema.Items = new OpenApiSchema { Type = "object" };
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.EntityReference:
                    //schema.Type = "object";
                    schema.Ref = $"#/components/schemas/Microsoft.Dynamics.CRM.{param.BoundEntityLogicalName}";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Float:
                    schema.Type = "number";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Integer:
                    //schema.Type = "integer";
                    schema.Ref = $"#/components/schemas/Int32";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Money:
                    schema.Type = "number";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Picklist:
                    schema.Ref = $"#/components/schemas/Int32";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.String:
                    schema.Type = "string";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.StringArray:
                    schema.Type = "array";
                    schema.Items = new OpenApiSchema { Type = "string" };
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Guid:
                    //schema.Type = "string";
                    //schema.Format = "uuid";
                    //schema.Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
                    schema.Ref = $"#/components/schemas/Uuid";
                    break;

                default:
                    schema.Type = "string";
                    break;
            }

            return schema;
        }



        


        private static Dictionary<string, OpenApiSecurityScheme> GenerateSecuritySchemes(string tenantId, string baseurl)
        {
            // Extract environment name from baseUrl (e.g., "org12345.crm.dynamics.com" from "https://org12345.crm.dynamics.com")
            var uri = new Uri(baseurl);
            var environmentHost = uri.Host; // Gets "org12345.crm.dynamics.com"

            return new Dictionary<string, OpenApiSecurityScheme>
            {
                ["azuread"] = new OpenApiSecurityScheme
                {
                    Type = "oauth2",
                    Flows = new OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            TokenUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token",
                            Scopes = new Dictionary<string, string>
                            {
                                [$"https://{environmentHost}/.default"] = "Access Dataverse APIs"
                            }
                        },
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize",
                            TokenUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token",
                            Scopes = new Dictionary<string, string>
                            {
                                [$"https://{environmentHost}/.default"] = "Access Dataverse APIs"
                            }
                        }
                    }
                }
            };
        }


        private static OpenApiSchema CreatePropertyForType(CustomApiRequestParameterProxy param)
        {
            var property = new OpenApiSchema
            {
                Description = param.Description
            };

            switch (param.Type)
            {
                case CustomAPIRequestParameter.Type_OptionSet.Boolean:
                    property.Type = "boolean";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.DateTime:
                    //property.Type = "string";
                    //property.Format = "date-time";
                    //property.Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$";
                    property.Ref = $"#/components/schemas/DateTime";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Decimal:
                    property.Type = "number";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Entity:
                    property.Type = "object";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.EntityCollection:
                    property.Type = "array";
                    property.Items = new OpenApiSchema { Type = "object" };
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.EntityReference:
                    //property.Type = "object";
                    property.Ref = $"#/components/schemas/Microsoft.Dynamics.CRM.{param.BoundEntityLogicalName}";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Float:
                    property.Type = "number";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Integer:
                    //property.Type = "integer";
                    property.Ref = $"#/components/schemas/Int32";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Money:
                    property.Type = "number";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Picklist:
                    //property.Type = "integer";
                    property.Ref = $"#/components/schemas/Int32";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.String:
                    property.Type = "string";
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.StringArray:
                    property.Type = "array";
                    property.Items = new OpenApiSchema { Type = "string" };
                    break;

                case CustomAPIRequestParameter.Type_OptionSet.Guid:
                    //property.Type = "string";
                    //property.Format = "uuid";
                    //property.Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
                    property.Ref = $"#/components/schemas/Uuid";
                    break;

                default:
                    property.Type = "string";
                    break;
            }

            return property;
        }

        private static OpenApiSchema CreatePropertyForResponseType(CustomApiResponsePropertyProxy responseProperty)
        {
            var property = new OpenApiSchema
            {
                Description = responseProperty.Description
            };

            switch (responseProperty.Type)
            {
                case CustomAPIResponseProperty.Type_OptionSet.Boolean:
                    property.Type = "boolean";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.DateTime:
                    //property.Type = "string";
                    //property.Format = "date-time";
                    //property.Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$";
                    property.Ref = $"#/components/schemas/DateTime";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.Decimal:
                    property.Type = "number";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.Entity:
                    property.Type = "object";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.EntityCollection:
                    property.Type = "array";
                    property.Items = new OpenApiSchema { Type = "object" };
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.EntityReference:
                    //property.Type = "object";
                    property.Ref = $"#/components/schemas/Microsoft.Dynamics.CRM.{responseProperty.BoundEntityLogicalName}";

                    break;

                case CustomAPIResponseProperty.Type_OptionSet.Float:
                    property.Type = "number";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.Integer:
                case CustomAPIResponseProperty.Type_OptionSet.Picklist:
                    //property.Type = "integer";
                    property.Ref = $"#/components/schemas/Int32";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.Money:
                    property.Type = "number";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.String:
                    property.Type = "string";
                    break;

                case CustomAPIResponseProperty.Type_OptionSet.Guid:
                    //property.Type = "string";
                    //property.Format = "uuid";
                    //property.Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
                    property.Ref = $"#/components/schemas/Uuid";
                    break;

                default:
                    property.Type = "string";
                    break;
            }

            return property;
        } 
    }
}


