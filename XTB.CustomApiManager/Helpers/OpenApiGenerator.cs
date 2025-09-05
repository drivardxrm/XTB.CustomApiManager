using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk;
using Newtonsoft.Json;
using XTB.CustomApiManager.Entities;
using XTB.CustomApiManager.Proxy;

namespace XTB.CustomApiManager.Helpers
{
    // OpenAPI Model Classes
    public class OpenApiDocument
    {
        [JsonProperty("openapi")]
        public string OpenApi { get; set; }

        [JsonProperty("info")]
        public OpenApiInfo Info { get; set; }

        [JsonProperty("servers")]
        public OpenApiServer[] Servers { get; set; }

        [JsonProperty("paths")]
        public Dictionary<string, object> Paths { get; set; }

        [JsonProperty("components")]
        public OpenApiComponents Components { get; set; }

        [JsonProperty("security")]
        public OpenApiSecurityRequirement[] Security { get; set; }
    }

    public class OpenApiInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }

    public class OpenApiServer
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class OpenApiComponents
    {
        [JsonProperty("schemas")]
        public Dictionary<string, object> Schemas { get; set; }

        [JsonProperty("securitySchemes")]
        public Dictionary<string, OpenApiSecurityScheme> SecuritySchemes { get; set; }
    }

    public class OpenApiRequestBody
    {
        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("content")]
        public Dictionary<string, OpenApiMediaType> Content { get; set; }
    }

    public class OpenApiMediaType
    {
        [JsonProperty("schema")]
        public OpenApiSchema Schema { get; set; }
    }

    public class OpenApiProperty
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public OpenApiSchema Items { get; set; }
    }

    public class OpenApiSchema
    {
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("properties", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, OpenApiProperty> Properties { get; set; }

        [JsonProperty("required", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Required { get; set; }

        [JsonProperty("format", NullValueHandling = NullValueHandling.Ignore)]
        public string Format { get; set; }

        [JsonProperty("pattern", NullValueHandling = NullValueHandling.Ignore)]
        public string Pattern { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public OpenApiSchema Items { get; set; }
    }

    public class OpenApiParameter
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("in", NullValueHandling = NullValueHandling.Ignore)]
        public string In { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("schema", NullValueHandling = NullValueHandling.Ignore)]
        public OpenApiSchema Schema { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
    }

    public class OpenApiSecurityScheme
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("flows")]
        public OpenApiOAuthFlows Flows { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class OpenApiOAuthFlows
    {
        [JsonProperty("authorizationCode")]
        public OpenApiOAuthFlow AuthorizationCode { get; set; }

        [JsonProperty("clientCredentials")]
        public OpenApiOAuthFlow ClientCredentials { get; set; }
    }

    public class OpenApiOAuthFlow
    {
        [JsonProperty("authorizationUrl")]
        public string AuthorizationUrl { get; set; }

        [JsonProperty("tokenUrl")]
        public string TokenUrl { get; set; }

        [JsonProperty("scopes")]
        public Dictionary<string, string> Scopes { get; set; }
    }

    public class OpenApiSecurityRequirement
    {
        [JsonProperty]
        public Dictionary<string, string[]> Requirements { get; set; }
    }

    public class OpenApiResponses
    {
        [JsonProperty("200")]
        public OpenApiResponse Success { get; set; }

        [JsonProperty("400")]
        public OpenApiResponse BadRequest { get; set; }

        [JsonProperty("401")]
        public OpenApiResponse Unauthorized { get; set; }

        [JsonProperty("500")]
        public OpenApiResponse InternalServerError { get; set; }
    }

    public class OpenApiResponse
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("content")]
        public Dictionary<string, OpenApiMediaType> Content { get; set; }
    }

    public static class OpenApiGenerator
    {
        public static string GenerateOpenApiJson(CustomApiProxy customApi, EntityCollection requestParameters, EntityCollection responseProperties, string baseUrl, string tenantId, string boundEntitySetName)
        {
            var openapi = OpenApiDocumentFor(customApi, requestParameters, responseProperties, baseUrl, tenantId, boundEntitySetName);

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(openapi, settings);
        }

        public static string GenerateOpenApiYaml(CustomApiProxy customApi, EntityCollection requestParameters, EntityCollection responseProperties, string baseUrl, string tenantId, string boundEntitySetName)
        {
            var openapi = OpenApiDocumentFor(customApi, requestParameters, responseProperties, baseUrl, tenantId, boundEntitySetName);

            return ConvertToYaml(openapi);
        }

        private static OpenApiDocument OpenApiDocumentFor(CustomApiProxy customApi, EntityCollection requestParameters, EntityCollection responseProperties, string baseUrl, string tenantId, string boundEntitySetName)
        {
            
            
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
                    Schemas = GenerateSchemas(customApi, requestParameters, responseProperties),
                    SecuritySchemes = GenerateSecuritySchemes(tenantId)
                },
                Security = new[]
                {
                    new OpenApiSecurityRequirement
                    {
                        Requirements = new Dictionary<string, string[]>
                        {
                            ["oauth2"] = new string[] { "https://service.powerapps.com/user_impersonation" }
                        }
                    }
                }
            };
        }

        private static Dictionary<string, object> GeneratePaths(CustomApiProxy customApi, EntityCollection requestParameters, EntityCollection responseProperties, string boundEntitySetName)
        {
            var paths = new Dictionary<string, object>();

            // Generate the API path
            string apiPath = $"/api/data/v9.2/{customApi.UniqueName}";
            if (customApi.BindingType == CustomAPI.BindingType_OptionSet.Entity)
            {
                apiPath = $"/api/data/v9.2/{boundEntitySetName}({{{customApi.BoundEntityLogicalName}id}})/Microsoft.Dynamics.CRM.{customApi.UniqueName}";
            }

            var httpMethod = customApi.IsFunction ? "get" : "post";
            var operation = new
            {
                tags = new[] { customApi.UniqueName },
                summary = customApi.DisplayName,
                description = customApi.Description,
                operationId = customApi.UniqueName,
                parameters = GenerateParameters(customApi, requestParameters),
                requestBody = !customApi.IsFunction ? GenerateRequestBody(requestParameters) : null,
                responses = GenerateResponses(responseProperties)
            };

            paths[apiPath] = new Dictionary<string, object> { { httpMethod, operation } };
            return paths;
        }

        private static OpenApiParameter[] GenerateParameters(CustomApiProxy customApi, EntityCollection requestParameters)
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
                        Type = "string", 
                        Format = "uuid",
                        Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$",
                    },
                    Description = $"key: {customApi.BoundEntityLogicalName}id"
                });
            }

            // Add query parameters for functions
            if (customApi.IsFunction)
            {
                foreach (Entity param in requestParameters.Entities)
                {
                    var paramProxy = new CustomApiRequestParameterProxy(param, true);
                    parameters.Add(new OpenApiParameter
                    {
                        Name = paramProxy.UniqueName,
                        In = "query",
                        Required = !paramProxy.IsOptional,
                        Schema = GetSchemaForType(paramProxy.Type),
                        Description = paramProxy.Description
                    });
                }
            }

            return parameters.ToArray();
        }

        private static OpenApiRequestBody GenerateRequestBody(EntityCollection requestParameters)
        {
            if (requestParameters.Entities.Count == 0)
                return null;

            var properties = new Dictionary<string, OpenApiProperty>();
            var required = new List<string>();

            foreach (Entity param in requestParameters.Entities)
            {
                var paramProxy = new CustomApiRequestParameterProxy(param, true);
                var property = CreatePropertyForType(paramProxy.Type, paramProxy.Description);

                properties[paramProxy.UniqueName] = property;

                if (!paramProxy.IsOptional)
                    required.Add(paramProxy.UniqueName);
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

        private static OpenApiResponses GenerateResponses(EntityCollection responseProperties)
        {
            var responses = new OpenApiResponses
            {
                BadRequest = new OpenApiResponse { Description = "Bad Request" },
                Unauthorized = new OpenApiResponse { Description = "Unauthorized" },
                InternalServerError = new OpenApiResponse { Description = "Internal Server Error" }
            };

            if (responseProperties.Entities.Count > 0)
            {
                var properties = new Dictionary<string, OpenApiProperty>();
                foreach (Entity prop in responseProperties.Entities)
                {
                    var propProxy = new CustomApiResponsePropertyProxy(prop, true);
                    var property = CreatePropertyForResponseType(propProxy.Type, propProxy.Description);

                    properties[propProxy.UniqueName] = property;
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

        private static Dictionary<string, object> GenerateSchemas(CustomApiProxy customApi, EntityCollection requestParameters, EntityCollection responseProperties)
        {
            // Could be expanded to include reusable schema definitions
            return new Dictionary<string, object>();
        }

        private static OpenApiSchema GetSchemaForType(CustomAPIRequestParameter.Type_OptionSet type)
        {
            var schema = new OpenApiSchema 
            { 
                Type = GetJsonTypeForDataverseType(type) 
            };

            // Handle specific type formatting
            switch (type)
            {
                case CustomAPIRequestParameter.Type_OptionSet.DateTime:
                    schema.Format = "date-time";
                    schema.Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$";
                    break;
                case CustomAPIRequestParameter.Type_OptionSet.Guid:
                    schema.Format = "uuid";
                    schema.Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
                    break;
                case CustomAPIRequestParameter.Type_OptionSet.EntityCollection:
                    schema.Items = new OpenApiSchema { Type = "object" };
                    break;
                case CustomAPIRequestParameter.Type_OptionSet.StringArray:
                    schema.Items = new OpenApiSchema { Type = "string" };
                    break;
            }

            return schema;
        }

        private static string GetJsonTypeForDataverseType(CustomAPIRequestParameter.Type_OptionSet type)
        {
            switch (type)
            {
                case CustomAPIRequestParameter.Type_OptionSet.Boolean:
                    return "boolean";
                case CustomAPIRequestParameter.Type_OptionSet.DateTime:
                    return "string";
                case CustomAPIRequestParameter.Type_OptionSet.Decimal:
                    return "number";
                case CustomAPIRequestParameter.Type_OptionSet.Float:
                    return "number";
                case CustomAPIRequestParameter.Type_OptionSet.Integer:
                    return "integer";
                case CustomAPIRequestParameter.Type_OptionSet.Money:
                    return "number";
                case CustomAPIRequestParameter.Type_OptionSet.String:
                    return "string";
                case CustomAPIRequestParameter.Type_OptionSet.Guid:
                    return "string";
                case CustomAPIRequestParameter.Type_OptionSet.Entity:
                    return "object";
                case CustomAPIRequestParameter.Type_OptionSet.EntityCollection:
                    return "array";
                case CustomAPIRequestParameter.Type_OptionSet.EntityReference:
                    return "object";
                case CustomAPIRequestParameter.Type_OptionSet.StringArray:
                    return "array";
                case CustomAPIRequestParameter.Type_OptionSet.Picklist:
                    return "integer";
                default:
                    return "string";
            }
        }

        private static string GetJsonTypeForDataverseType(CustomAPIResponseProperty.Type_OptionSet type)
        {
            switch (type)
            {
                case CustomAPIResponseProperty.Type_OptionSet.Boolean:
                    return "boolean";
                case CustomAPIResponseProperty.Type_OptionSet.DateTime:
                    return "string";
                case CustomAPIResponseProperty.Type_OptionSet.Decimal:
                    return "number";
                case CustomAPIResponseProperty.Type_OptionSet.Float:
                    return "number";
                case CustomAPIResponseProperty.Type_OptionSet.Integer:
                    return "integer";
                case CustomAPIResponseProperty.Type_OptionSet.Money:
                    return "number";
                case CustomAPIResponseProperty.Type_OptionSet.String:
                    return "string";
                case CustomAPIResponseProperty.Type_OptionSet.Entity:
                    return "object";
                case CustomAPIResponseProperty.Type_OptionSet.EntityCollection:
                    return "array";
                case CustomAPIResponseProperty.Type_OptionSet.EntityReference:
                    return "object";
                default:
                    return "string";
            }
        }

        private static string ConvertToYaml(object obj, int indentLevel = 0)
        {
            var yaml = new StringBuilder();
            var indent = new string(' ', indentLevel * 2);

            if (obj == null)
            {
                return "null";
            }

            var type = obj.GetType();

            if (type.IsArray || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>)))
            {
                var enumerable = obj as System.Collections.IEnumerable;
                foreach (var item in enumerable)
                {
                    yaml.AppendLine($"{indent}- {ConvertToYaml(item, indentLevel + 1).TrimStart()}");
                }
            }
            else if (type == typeof(Dictionary<string, object>))
            {
                var dict = obj as Dictionary<string, object>;
                foreach (var kvp in dict)
                {
                    var value = ConvertToYaml(kvp.Value, indentLevel + 1);
                    if (IsComplexType(kvp.Value))
                    {
                        yaml.AppendLine($"{indent}{EscapeYamlKey(kvp.Key)}:");
                        yaml.Append(value);
                    }
                    else
                    {
                        yaml.AppendLine($"{indent}{EscapeYamlKey(kvp.Key)}: {value.TrimStart()}");
                    }
                }
            }
            else if (type.IsAnonymousType())
            {
                var properties = type.GetProperties();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(obj);
                    var yamlValue = ConvertToYaml(value, indentLevel + 1);
                    var propertyName = prop.Name == "in" ? "in" : prop.Name; // Handle @in parameter

                    if (IsComplexType(value))
                    {
                        yaml.AppendLine($"{indent}{EscapeYamlKey(propertyName)}:");
                        yaml.Append(yamlValue);
                    }
                    else
                    {
                        yaml.AppendLine($"{indent}{EscapeYamlKey(propertyName)}: {yamlValue.TrimStart()}");
                    }
                }
            }
            else if (type == typeof(OpenApiDocument) || type == typeof(OpenApiInfo) || type == typeof(OpenApiServer) || 
                     type == typeof(OpenApiComponents) || type == typeof(OpenApiSecurityScheme) || 
                     type == typeof(OpenApiOAuthFlows) || type == typeof(OpenApiOAuthFlow) || 
                     type == typeof(OpenApiSecurityRequirement) || type == typeof(OpenApiResponses) || 
                     type == typeof(OpenApiResponse) || type == typeof(OpenApiRequestBody) || 
                     type == typeof(OpenApiMediaType) || type == typeof(OpenApiSchema) || 
                     type == typeof(OpenApiProperty) || type == typeof(OpenApiParameter))
            {
                var properties = type.GetProperties();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(obj);
                    if (value == null) continue;

                    var yamlValue = ConvertToYaml(value, indentLevel + 1);
                    var propertyName = GetJsonPropertyName(prop) ?? prop.Name.ToLowerInvariant();

                    if (IsComplexType(value))
                    {
                        yaml.AppendLine($"{indent}{EscapeYamlKey(propertyName)}:");
                        yaml.Append(yamlValue);
                    }
                    else
                    {
                        yaml.AppendLine($"{indent}{EscapeYamlKey(propertyName)}: {yamlValue.TrimStart()}");
                    }
                }
            }
            else if (type == typeof(string))
            {
                var str = obj.ToString();
                if (str.Contains('\n') || str.Contains('\r') || str.Contains('"') || str.Contains('\''))
                {
                    return $"\"{str.Replace("\"", "\\\"")}\"";
                }
                return str;
            }
            else if (type == typeof(bool))
            {
                return obj.ToString().ToLowerInvariant();
            }
            else if (type.IsNumeric())
            {
                return obj.ToString();
            }
            else
            {
                return obj.ToString();
            }

            return yaml.ToString();
        }

        private static string GetJsonPropertyName(System.Reflection.PropertyInfo property)
        {
            var jsonPropertyAttribute = property.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault() as JsonPropertyAttribute;
            return jsonPropertyAttribute?.PropertyName;
        }

        private static bool IsComplexType(object value)
        {
            if (value == null) return false;

            var type = value.GetType();
            return type.IsAnonymousType() ||
                   type == typeof(Dictionary<string, object>) ||
                   type.IsArray ||
                   (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>)) ||
                   type == typeof(OpenApiDocument) ||
                   type == typeof(OpenApiInfo) ||
                   type == typeof(OpenApiServer) ||
                   type == typeof(OpenApiComponents) ||
                   type == typeof(OpenApiRequestBody) ||
                   type == typeof(OpenApiMediaType) ||
                   type == typeof(OpenApiSchema) ||
                   type == typeof(OpenApiProperty) ||
                   type == typeof(OpenApiParameter) ||
                   type == typeof(OpenApiSecurityScheme) ||
                   type == typeof(OpenApiOAuthFlows) ||
                   type == typeof(OpenApiOAuthFlow) ||
                   type == typeof(OpenApiSecurityRequirement) ||
                   type == typeof(OpenApiResponses) ||
                   type == typeof(OpenApiResponse);
        }

        private static string ConvertToYaml(OpenApiDocument document)
        {
            var yaml = new StringBuilder();
            
            yaml.AppendLine($"openapi: {document.OpenApi}");
            
            // Info section
            yaml.AppendLine("info:");
            yaml.AppendLine($"  title: {EscapeYamlValue(document.Info.Title)}");
            yaml.AppendLine($"  description: {EscapeYamlValue(document.Info.Description)}");
            yaml.AppendLine($"  version: {document.Info.Version}");
            
            // Servers section
            yaml.AppendLine("servers:");
            foreach (var server in document.Servers)
            {
                yaml.AppendLine($"  - url: {server.Url}");
            }
            
            // Security section
            if (document.Security != null && document.Security.Length > 0)
            {
                yaml.AppendLine("security:");
                foreach (var securityReq in document.Security)
                {
                    yaml.AppendLine("  - oauth2:");
                    foreach (var requirement in securityReq.Requirements)
                    {
                        foreach (var scope in requirement.Value)
                        {
                            yaml.AppendLine($"      - {scope}");
                        }
                    }
                }
            }
            
            // Paths section
            yaml.AppendLine("paths:");
            foreach (var path in document.Paths)
            {
                yaml.AppendLine($"  {EscapeYamlKey(path.Key)}:");
                var pathItem = path.Value as Dictionary<string, object>;
                if (pathItem != null)
                {
                    foreach (var operation in pathItem)
                    {
                        yaml.AppendLine($"    {operation.Key}:");
                        AppendOperation(yaml, operation.Value, 6);
                    }
                }
            }
            
            // Components section
            yaml.AppendLine("components:");
            yaml.AppendLine("  schemas: {}");
            
            // Security schemes section
            if (document.Components.SecuritySchemes != null && document.Components.SecuritySchemes.Any())
            {
                yaml.AppendLine("  securitySchemes:");
                foreach (var securityScheme in document.Components.SecuritySchemes)
                {
                    yaml.AppendLine($"    {securityScheme.Key}:");
                    yaml.AppendLine($"      type: {securityScheme.Value.Type}");
                    yaml.AppendLine($"      description: {EscapeYamlValue(securityScheme.Value.Description)}");
                    yaml.AppendLine("      flows:");
                    
                    if (securityScheme.Value.Flows.AuthorizationCode != null)
                    {
                        yaml.AppendLine("        authorizationCode:");
                        yaml.AppendLine($"          authorizationUrl: {securityScheme.Value.Flows.AuthorizationCode.AuthorizationUrl}");
                        yaml.AppendLine($"          tokenUrl: {securityScheme.Value.Flows.AuthorizationCode.TokenUrl}");
                        yaml.AppendLine("          scopes:");
                        foreach (var scope in securityScheme.Value.Flows.AuthorizationCode.Scopes)
                        {
                            yaml.AppendLine($"            {EscapeYamlKey(scope.Key)}: {EscapeYamlValue(scope.Value)}");
                        }
                    }
                    
                    if (securityScheme.Value.Flows.ClientCredentials != null)
                    {
                        yaml.AppendLine("        clientCredentials:");
                        yaml.AppendLine($"          tokenUrl: {securityScheme.Value.Flows.ClientCredentials.TokenUrl}");
                        yaml.AppendLine("          scopes:");
                        foreach (var scope in securityScheme.Value.Flows.ClientCredentials.Scopes)
                        {
                            yaml.AppendLine($"            {EscapeYamlKey(scope.Key)}: {EscapeYamlValue(scope.Value)}");
                        }
                    }
                }
            }
            
            return yaml.ToString();
        }

        private static void AppendOperation(StringBuilder yaml, object operation, int indent)
        {
            var indentStr = new string(' ', indent);
            
            if (operation.GetType().IsAnonymousType())
            {
                var properties = operation.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    var value = prop.GetValue(operation);
                    if (value == null) continue;
                    
                    var propertyName = prop.Name;
                    
                    switch (propertyName.ToLowerInvariant())
                    {
                        case "tags":
                            if (value is string[] tags && tags.Length > 0)
                            {
                                yaml.AppendLine($"{indentStr}tags:");
                                foreach (var tag in tags)
                                {
                                    yaml.AppendLine($"{indentStr}  - {EscapeYamlValue(tag)}");
                                }
                            }
                            break;
                        case "summary":
                        case "description":
                        case "operationid":
                            yaml.AppendLine($"{indentStr}{propertyName}: {EscapeYamlValue(value.ToString())}");
                            break;
                        case "parameters":
                            AppendParameters(yaml, value as OpenApiParameter[], indent);
                            break;
                        case "requestbody":
                            if (value != null)
                                AppendRequestBody(yaml, value as OpenApiRequestBody, indent);
                            break;
                        case "responses":
                            AppendResponses(yaml, value, indent);
                            break;
                    }
                }
            }
        }

        private static void AppendParameters(StringBuilder yaml, OpenApiParameter[] parameters, int indent)
        {
            if (parameters == null || parameters.Length == 0) return;
            
            var indentStr = new string(' ', indent);
            yaml.AppendLine($"{indentStr}parameters:");
            
            foreach (var param in parameters)
            {
                yaml.AppendLine($"{indentStr}  - name: {param.Name}");
                yaml.AppendLine($"{indentStr}    in: {param.In}");
                yaml.AppendLine($"{indentStr}    required: {param.Required.ToString().ToLowerInvariant()}");
                yaml.AppendLine($"{indentStr}    schema:");
                yaml.AppendLine($"{indentStr}      type: {param.Schema.Type}");
                
                if (!string.IsNullOrEmpty(param.Schema.Format))
                    yaml.AppendLine($"{indentStr}      format: {param.Schema.Format}");
                
                if (!string.IsNullOrEmpty(param.Schema.Pattern))
                    yaml.AppendLine($"{indentStr}      pattern: {EscapeYamlValue(param.Schema.Pattern)}");
                
                // Handle array items (only if not null)
                if (param.Schema.Items != null)
                {
                    yaml.AppendLine($"{indentStr}      items:");
                    yaml.AppendLine($"{indentStr}        type: {param.Schema.Items.Type}");
                }
                
                if (!string.IsNullOrEmpty(param.Description))
                    yaml.AppendLine($"{indentStr}    description: {EscapeYamlValue(param.Description)}");
            }
        }

        private static void AppendRequestBody(StringBuilder yaml, OpenApiRequestBody requestBody, int indent)
        {
            var indentStr = new string(' ', indent);
            yaml.AppendLine($"{indentStr}requestBody:");
            yaml.AppendLine($"{indentStr}  required: {requestBody.Required.ToString().ToLowerInvariant()}");
            yaml.AppendLine($"{indentStr}  content:");
            
            foreach (var content in requestBody.Content)
            {
                yaml.AppendLine($"{indentStr}    {EscapeYamlKey(content.Key)}:");
                yaml.AppendLine($"{indentStr}      schema:");
                yaml.AppendLine($"{indentStr}        type: {content.Value.Schema.Type}");
                
                if (content.Value.Schema.Properties != null && content.Value.Schema.Properties.Any())
                {
                    yaml.AppendLine($"{indentStr}        properties:");
                    foreach (var prop in content.Value.Schema.Properties)
                    {
                        yaml.AppendLine($"{indentStr}          {prop.Key}:");
                        yaml.AppendLine($"{indentStr}            type: {prop.Value.Type}");
                        
                        // Only add format if not null/empty
                        if (!string.IsNullOrEmpty(prop.Value.Format))
                            yaml.AppendLine($"{indentStr}            format: {prop.Value.Format}");
                        
                        // Only add pattern if not null/empty
                        if (!string.IsNullOrEmpty(prop.Value.Pattern))
                            yaml.AppendLine($"{indentStr}            pattern: {EscapeYamlValue(prop.Value.Pattern)}");
                        
                        // Only add items if not null and type is array
                        if (prop.Value.Type == "array" && prop.Value.Items != null)
                        {
                            yaml.AppendLine($"{indentStr}            items:");
                            yaml.AppendLine($"{indentStr}              type: {prop.Value.Items.Type}");
                        }
                        
                        // Only add description if not null/empty
                        if (!string.IsNullOrEmpty(prop.Value.Description))
                            yaml.AppendLine($"{indentStr}            description: {EscapeYamlValue(prop.Value.Description)}");
                    }
                }
                
                if (content.Value.Schema.Required != null && content.Value.Schema.Required.Any())
                {
                    yaml.AppendLine($"{indentStr}        required:");
                    foreach (var req in content.Value.Schema.Required)
                    {
                        yaml.AppendLine($"{indentStr}          - {req}");
                    }
                }
            }
        }

        private static void AppendResponses(StringBuilder yaml, object responses, int indent)
        {
            var indentStr = new string(' ', indent);
            yaml.AppendLine($"{indentStr}responses:");
            
            if (responses is OpenApiResponses apiResponses)
            {
                // Success response (200)
                if (apiResponses.Success != null)
                {
                    yaml.AppendLine($"{indentStr}  \"200\":");
                    yaml.AppendLine($"{indentStr}    description: {EscapeYamlValue(apiResponses.Success.Description)}");
                    
                    if (apiResponses.Success.Content != null && apiResponses.Success.Content.Any())
                    {
                        yaml.AppendLine($"{indentStr}    content:");
                        foreach (var content in apiResponses.Success.Content)
                        {
                            yaml.AppendLine($"{indentStr}      {EscapeYamlKey(content.Key)}:");
                            yaml.AppendLine($"{indentStr}        schema:");
                            yaml.AppendLine($"{indentStr}          type: {content.Value.Schema.Type}");
                            
                            if (content.Value.Schema.Properties != null && content.Value.Schema.Properties.Any())
                            {
                                yaml.AppendLine($"{indentStr}          properties:");
                                foreach (var prop in content.Value.Schema.Properties)
                                {
                                    yaml.AppendLine($"{indentStr}            {prop.Key}:");
                                    yaml.AppendLine($"{indentStr}              type: {prop.Value.Type}");
                                    
                                    // Only add format if not null/empty
                                    if (!string.IsNullOrEmpty(prop.Value.Format))
                                        yaml.AppendLine($"{indentStr}              format: {prop.Value.Format}");
                                    
                                    // Only add pattern if not null/empty
                                    if (!string.IsNullOrEmpty(prop.Value.Pattern))
                                        yaml.AppendLine($"{indentStr}              pattern: {EscapeYamlValue(prop.Value.Pattern)}");
                                    
                                    // Only add items if not null and type is array
                                    if (prop.Value.Type == "array" && prop.Value.Items != null)
                                    {
                                        yaml.AppendLine($"{indentStr}              items:");
                                        yaml.AppendLine($"{indentStr}                type: {prop.Value.Items.Type}");
                                    }
                                    
                                    // Only add description if not null/empty
                                    if (!string.IsNullOrEmpty(prop.Value.Description))
                                        yaml.AppendLine($"{indentStr}              description: {EscapeYamlValue(prop.Value.Description)}");
                                }
                            }
                        }
                    }
                }
                
                // Error responses (same pattern - only include if not null)
                if (apiResponses.BadRequest != null)
                {
                    yaml.AppendLine($"{indentStr}  \"400\":");
                    yaml.AppendLine($"{indentStr}    description: {EscapeYamlValue(apiResponses.BadRequest.Description)}");
                }
                
                if (apiResponses.Unauthorized != null)
                {
                    yaml.AppendLine($"{indentStr}  \"401\":");
                    yaml.AppendLine($"{indentStr}    description: {EscapeYamlValue(apiResponses.Unauthorized.Description)}");
                }
                
                if (apiResponses.InternalServerError != null)
                {
                    yaml.AppendLine($"{indentStr}  \"500\":");
                    yaml.AppendLine($"{indentStr}    description: {EscapeYamlValue(apiResponses.InternalServerError.Description)}");
                }
            }
        }

       

        private static Dictionary<string, OpenApiSecurityScheme> GenerateSecuritySchemes(string tenantId)
        {
            return new Dictionary<string, OpenApiSecurityScheme>
            {
                ["oauth2"] = new OpenApiSecurityScheme
                {
                    Type = "oauth2",
                    Description = "OAuth2 authentication for Microsoft Dataverse",
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/authorize",
                            TokenUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token",
                            Scopes = new Dictionary<string, string>
                            {
                                ["https://service.powerapps.com/user_impersonation"] = "Access Dataverse as the signed-in user"
                            }
                        },
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            TokenUrl = $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token",
                            Scopes = new Dictionary<string, string>
                            {
                                ["https://service.powerapps.com/.default"] = "Access Dataverse with application permissions"
                            }
                        }
                    }
                }
            };
        }

        private static OpenApiProperty CreatePropertyForType(CustomAPIRequestParameter.Type_OptionSet type, string description)
        {
            var property = new OpenApiProperty
            {
                Type = GetJsonTypeForDataverseType(type),
                Description = description
            };

            // Handle specific type formatting
            switch (type)
            {
                case CustomAPIRequestParameter.Type_OptionSet.DateTime:
                    property.Format = "date-time";
                    property.Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$";
                    break;
                case CustomAPIRequestParameter.Type_OptionSet.Guid:
                    property.Format = "uuid";
                    property.Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
                    break;
                case CustomAPIRequestParameter.Type_OptionSet.EntityCollection:
                    property.Items = new OpenApiSchema { Type = "object" };
                    break;
                case CustomAPIRequestParameter.Type_OptionSet.StringArray:
                    property.Items = new OpenApiSchema { Type = "string" };
                    break;
            }

            return property;
        }

        private static OpenApiProperty CreatePropertyForResponseType(CustomAPIResponseProperty.Type_OptionSet type, string description)
        {
            var property = new OpenApiProperty
            {
                Type = GetJsonTypeForDataverseType(type),
                Description = description
            };

            // Handle specific type formatting
            switch (type)
            {
                case CustomAPIResponseProperty.Type_OptionSet.DateTime:
                    property.Format = "date-time";
                    property.Pattern = @"^[0-9]{4,}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])T([01][0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]([.][0-9]{1,12})?(Z|[+-][0-9][0-9]:[0-9][0-9])$";
                    break;
                case CustomAPIResponseProperty.Type_OptionSet.Guid:
                    property.Format = "uuid";
                    property.Pattern = "^[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}$";
                    break;
                case CustomAPIResponseProperty.Type_OptionSet.EntityCollection:
                    property.Items = new OpenApiSchema { Type = "object" };
                    break;
            }

            return property;
        }

        private static string EscapeYamlValue(string value)
        {
            if (string.IsNullOrEmpty(value)) 
                return "\"\"";
            
            // Check if the value needs to be quoted
            if (value.Contains('\n') || 
                value.Contains('\r') || 
                value.Contains('"') || 
                value.Contains('\'') || 
                value.Contains(':') || 
                value.Contains('#') || 
                value.Contains('|') ||
                value.Contains('>') ||
                value.Contains('[') ||
                value.Contains(']') ||
                value.Contains('{') ||
                value.Contains('}') ||
                value.Contains('&') ||
                value.Contains('*') ||
                value.Contains('!') ||
                value.Contains('@') ||
                value.Contains('`') ||
                value.StartsWith(" ") || 
                value.EndsWith(" ") ||
                value.StartsWith("-") ||
                value.StartsWith("?") ||
                value.StartsWith("%") ||
                value.Trim() != value)
            {
                // Escape internal quotes and wrap in quotes
                return $"\"{value.Replace("\"", "\\\"")}\"";
            }
            
            // Check for YAML reserved words that need quoting
            var lowerValue = value.ToLowerInvariant();
            if (lowerValue == "true" || 
                lowerValue == "false" || 
                lowerValue == "null" || 
                lowerValue == "yes" || 
                lowerValue == "no" || 
                lowerValue == "on" || 
                lowerValue == "off")
            {
                return $"\"{value}\"";
            }
            
            // Check if it looks like a number
            if (decimal.TryParse(value, out _) || 
                int.TryParse(value, out _) || 
                double.TryParse(value, out _))
            {
                return $"\"{value}\"";
            }
            
            return value;
        }

        private static string EscapeYamlKey(string key)
        {
            if (string.IsNullOrEmpty(key)) 
                return "\"\"";
            
            // Check if the key needs to be quoted
            if (key.Contains(' ') || 
                key.Contains(':') || 
                key.Contains('-') || 
                key.Contains('[') || 
                key.Contains(']') || 
                key.Contains('{') || 
                key.Contains('}') || 
                key.Contains('(') || 
                key.Contains(')') || 
                key.Contains(',') || 
                key.Contains('.') || 
                key.Contains('/') || 
                key.Contains('\\') ||
                key.Contains('"') || 
                key.Contains('\'') || 
                key.Contains('#') || 
                key.Contains('&') || 
                key.Contains('*') || 
                key.Contains('!') || 
                key.Contains('|') || 
                key.Contains('>') || 
                key.Contains('<') || 
                key.Contains('=') || 
                key.Contains('%') || 
                key.Contains('@') || 
                key.Contains('`') || 
                key.Contains('~') || 
                key.Contains('?') ||
                key.StartsWith(" ") || 
                key.EndsWith(" ") ||
                key.StartsWith("-") ||
                key.StartsWith("0") ||
                char.IsDigit(key[0]))
            {
                // Escape internal quotes and wrap in quotes
                return $"\"{key.Replace("\"", "\\\"")}\"";
            }
    
            return key;
        }
    }
}

