## Table of Contents
- [Namespace: NatLaRestTest.Bindings.Bindings.Actions](#namespace-natlaresttestbindingsbindingsactions)
  - [Class: BasicVariableBindings](#class-basicvariablebindings)
  - [Class: HttpClientRequestBindings](#class-httpclientrequestbindings)
  - [Class: HttpClientRequestStreamBindings](#class-httpclientrequeststreambindings)
  - [Class: HttpResponseStreamBindings](#class-httpresponsestreambindings)
  - [Class: HttpResponseVariableBindings](#class-httpresponsevariablebindings)
  - [Class: VariableJsonBindings](#class-variablejsonbindings)
  - [Class: VariableXmlBindings](#class-variablexmlbindings)
- [Namespace: NatLaRestTest.Bindings.Bindings.Actions.ManipulateVariableActions](#namespace-natlaresttestbindingsbindingsactionsmanipulatevariableactions)
  - [Class: DateTimeVariableManipulationBindings](#class-datetimevariablemanipulationbindings)
  - [Class: NumericVariableManipulationBindings](#class-numericvariablemanipulationbindings)
  - [Class: StringVariableManipulationBindings](#class-stringvariablemanipulationbindings)
- [Namespace: NatLaRestTest.Bindings.Bindings.Actions.SetVariableActions](#namespace-natlaresttestbindingsbindingsactionssetvariableactions)
  - [Class: DateTimeVariableBindings](#class-datetimevariablebindings)
  - [Class: RandomNumberVariableBindings](#class-randomnumbervariablebindings)
  - [Class: RandomStringVariableBindings](#class-randomstringvariablebindings)
  - [Class: SetFromFile](#class-setfromfile)
  - [Class: StringOperationBindings](#class-stringoperationbindings)
- [Namespace: NatLaRestTest.Bindings.Bindings.Assertions](#namespace-natlaresttestbindingsbindingsassertions)
  - [Class: BasicVariableAssertions](#class-basicvariableassertions)
  - [Class: CollectionVariableAssertions](#class-collectionvariableassertions)
  - [Class: HttpResponseAssertionBindings](#class-httpresponseassertionbindings)
  - [Class: JsonSchemaAssertions](#class-jsonschemaassertions)
  - [Class: NumericVariablePathAssertions](#class-numericvariablepathassertions)
  - [Class: RegExAssertions](#class-regexassertions)
  - [Class: StringVariableAssertions](#class-stringvariableassertions)
- [Namespace: NatLaRestTest.Bindings.Bindings.Assertions.JsonPath](#namespace-natlaresttestbindingsbindingsassertionsjsonpath)
  - [Class: BasicVariableJsonPathAssertions](#class-basicvariablejsonpathassertions)
  - [Class: CollectionVariableJsonPathAssertions](#class-collectionvariablejsonpathassertions)
  - [Class: NumericVariableJsonPathAssertions](#class-numericvariablejsonpathassertions)
  - [Class: StringVariableJsonPathAssertions](#class-stringvariablejsonpathassertions)
- [Namespace: NatLaRestTest.Bindings.Bindings.Setup](#namespace-natlaresttestbindingsbindingssetup)
  - [Class: HttpClientConfigurationBindings](#class-httpclientconfigurationbindings)

<a id="namespace-natlaresttestbindingsbindingsactions"></a>
# Namespace: NatLaRestTest.Bindings.Bindings.Actions

<a id="class-basicvariablebindings"></a>
## Class: BasicVariableBindings
<br>            Step bindings for setting scenario variables to explicit string values (single line or multiline).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetVariableManually | When the value '(.\*)' is stored in variable '(.\*)' | When step: Sets the specified scenario variable to the provided string value.<br>*variableName*: The name of the variable to set.; *value*: The value to assign to the variable. |
| SetVariableManuallyMultiline | When the following value is stored in variable '(.\*)': | When step: Sets the specified scenario variable to the provided multiline string value.<br>*variableName*: The name of the variable to set.; *value*: The value to assign to the variable. |


<a id="class-httpclientrequestbindings"></a>
## Class: HttpClientRequestBindings
<br>            Step bindings for issuing HTTP requests with the shared HTTP client (GET and generic verbs, with/without body).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GetRequest | When a request to '(.\*)' is made | When step: Sends an HTTP GET request to the specified relative path using the shared HTTP client.<br>*relativePath*: The relative path for the request (e.g., "products/1"). |
| SendRequestWithBodyWithContentType | When a '(.\*)' request to '(.\*)' is made with content type '(.\*)' and the following request body: | When step: Sends an HTTP request with the specified method, content type, and request body to the relative path.<br>*httpMethod*: The HTTP method (e.g., POST or PUT).; *relativePath*: The relative path for the request.; *contentType*: The content type to set (e.g., "application/json").; *requestBody*: The raw request body payload. |
| SendRequestWithBodyWithoutContentType | When a '(.\*)' request to '(.\*)' is made with the following request body: | When step: Sends an HTTP request with the specified method and request body to the relative path. Uses the default content type "application/json".<br>*httpMethod*: The HTTP method (e.g., POST or PUT).; *relativePath*: The relative path for the request.; *requestBody*: The raw request body payload. |
| SendRequestWithoutBody | When a '(.\*)' request to '(.\*)' is made | When step: Sends an HTTP request with the specified method to the relative path without a request body.<br>*httpMethod*: The HTTP method (e.g., GET, POST, PUT, DELETE).; *relativePath*: The relative path for the request. |


<a id="class-httpclientrequeststreambindings"></a>
## Class: HttpClientRequestStreamBindings

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| UploadFile | When a '(.\*)' request is made to '(.\*)' with the contents of file '(.\*)' as stream content |  |
| UploadFile | When a '(.\*)' request is made to '(.\*)' with the contents of file '(.\*)' as stream content with content type '(.\*)' |  |


<a id="class-httpresponsestreambindings"></a>
## Class: HttpResponseStreamBindings
<br>            Step bindings for working with HTTP response streams, including saving to a file and storing the stream length.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SaveResponseStreamToFile | When the response stream is saved to file '(.\*)' | When step: Saves the current response stream to a file.<br>*filePath*: The target file path. |
| StoreResponseStreamLengthInVariable | When the length of the response stream is stored in variable '(.\*)' | When step: Stores the length of the current response stream (in bytes) into a scenario variable.<br>*variableName*: The target variable name. |


<a id="class-httpresponsevariablebindings"></a>
## Class: HttpResponseVariableBindings
<br>            Step bindings for storing parts of the HTTP response (e.g., body) into scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| StoreResponseBody | When the response body is stored in variable '(.\*)' | When step: Stores the body of the current HTTP response as a string in the specified variable. Asserts that a response is available.<br>*variableName*: The name of the variable to store the response body. |
| StoreResponseHeaderValue | When the value of header '(.\*)' is stored in variable '(.\*)' | When step: Stores the value of the specified response header into a scenario variable.<br>*headerName*: The response header to read.; *variableName*: The target variable name. |


<a id="class-variablejsonbindings"></a>
## Class: VariableJsonBindings
<br>            Step bindings for extracting values from JSON variables using JSONPath and storing them in scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetVariableFromJPath | When the value of JSONPath '(.\*)' in variable '(.\*)' is stored in variable '(.\*)' | When step: Extracts a value from a JSON variable via JSONPath and stores it as a new variable (stringified).<br>*jPath*: The JSONPath expression to evaluate.; *sourceVariableName*: The name of the source variable containing JSON.; *targetVariableName*: The name of the variable to set with the extracted value. |


<a id="class-variablexmlbindings"></a>
## Class: VariableXmlBindings
<br>            Step bindings for extracting values from XML using XPath and storing them in scenario variables.<br>            The XML source is expected to be provided in the scenario variable named 'xml'.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetVariableFromXPath | When when the value of XPath '(.\*)' is stored in variable '(.\*)' | When step: Evaluates the given XPath expression against the XML stored in scenario variable 'xml'<br>            and stores the resulting node/attribute string value in the specified target variable.<br>*xPath*: The XPath expression to evaluate.; *targetVariableName*: The name of the variable where the extracted value will be stored. |

<a id="namespace-natlaresttestbindingsbindingsactionsmanipulatevariableactions"></a>
# Namespace: NatLaRestTest.Bindings.Bindings.Actions.ManipulateVariableActions

<a id="class-datetimevariablemanipulationbindings"></a>
## Class: DateTimeVariableManipulationBindings
<br>            Step bindings for manipulating existing DateTime variables by adding or subtracting a TimeSpan, and computing differences.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AddTimeSpanToVariable | When the timespan '(.\*)' is added to the value of variable '(.\*)' | When step: Adds the provided timespan to the current DateTime value stored in the specified variable.<br>*timeSpan*: The timespan to add (e.g., "01:30:00" for 1h30m).; *variableName*: The target variable name. |
| SubtractDateTimeFromDateTime | When the date '(.\*)' is subtracted from the value of variable '(.\*)' |  |
| SubtractTimeSpanFromVariable | When the timespan '(.\*)' is subtracted from the value of variable '(.\*)' | When step: Subtracts the provided timespan from the current DateTime value stored in the specified variable.<br>*timeSpan*: The timespan to subtract.; *variableName*: The target variable name. |


<a id="class-numericvariablemanipulationbindings"></a>
## Class: NumericVariableManipulationBindings
<br>            Step bindings for manipulating existing numeric variables by applying arithmetic operations.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AddNumberToVariable | When the number '(.\*)' is added to the value of variable '(.\*)' | When step: Adds the provided number to the current numeric value stored in the specified variable.<br>*number*: The number to add.; *variableName*: The target variable name. |
| DivideNumberByVariable | When the number '(.\*)' is divided by the value of variable '(.\*)' | When step: Divides the provided number by the current numeric value stored in the specified variable (number / variable).<br>*number*: The dividend.; *variableName*: The variable containing the divisor. |
| DivideVariableByNumber | When the value of variable '(.\*)' is divided by the number '(.\*)' | When step (inverse of above): Divides the current numeric value stored in the specified variable by the provided number (variable / number).<br>*variableName*: The variable containing the dividend.; *number*: The divisor. |
| MultiplyNumberWithVariable | When the number '(.\*)' is multiplied with the value of variable '(.\*)' | When step: Multiplies the provided number with the current numeric value stored in the specified variable.<br>*number*: The number to multiply with.; *variableName*: The target variable name. |
| SubtractNumberFromVariable | When the number '(.\*)' is subtracted from the value of variable '(.\*)' | When step: Subtracts the provided number from the current numeric value stored in the specified variable (variable - number).<br>*number*: The number to subtract.; *variableName*: The target variable name. |
| SubtractVariableFromNumber | When the value of variable '(.\*)' is subtracted from the number '(.\*)' | When step (inverse of above): Subtracts the current numeric value stored in the specified variable from the provided number (number - variable).<br>*variableName*: The variable containing the subtrahend.; *number*: The minuend. |


<a id="class-stringvariablemanipulationbindings"></a>
## Class: StringVariableManipulationBindings
<br>            Step bindings for manipulating existing string variables by appending, prepending, or replacing content.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AppendStringToVariable | When the string '(.\*)' is appended to the value of variable '(.\*)' | When step: Appends a literal string to the end of the specified variable's current value.<br>*valueToAppend*: The string to append.; *variableName*: The target variable name. |
| PrependStringToVariable | When the string '(.\*)' is prepended to the value of variable '(.\*)' | When step: Prepends a literal string to the beginning of the specified variable's current value.<br>*valueToPrepend*: The string to prepend.; *variableName*: The target variable name. |
| ReplaceStringInVariable | When the string '(.\*)' is replaced with '(.\*)' in the value of variable '(.\*)' | When step: Replaces all occurrences of a substring with another within the specified variable's value.<br>*oldValue*: The substring to replace.; *newValue*: The replacement string.; *variableName*: The target variable name. |

<a id="namespace-natlaresttestbindingsbindingsactionssetvariableactions"></a>
# Namespace: NatLaRestTest.Bindings.Bindings.Actions.SetVariableActions

<a id="class-datetimevariablebindings"></a>
## Class: DateTimeVariableBindings
<br>            Step bindings for storing date/time based values into scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetCurrentDate | When ^the current date is stored in variable '([^']+)'\\$ | When step: Stores the current date/time as a string in the specified variable using the system default format.<br>*variableName*: The variable name to store the current date/time into. |
| SetCurrentDateFormatted | When ^the current date is stored in variable '([^']+)' in format '([^']+)'\\$ | When step: Stores the current date/time as a string in the specified variable using the provided .NET date/time format string.<br>*variableName*: The variable name to store the formatted date/time into.; *dateFormat*: A .NET date/time format string (e.g., "yyyy-MM-dd"). |


<a id="class-randomnumbervariablebindings"></a>
## Class: RandomNumberVariableBindings
<br>            Step bindings for generating and storing random numeric values in scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetRandomDoubleInRange | When a random double between (.\*) and (.\*) is stored in variable '(.\*)' | When step: Generates a random double within the inclusive lower and exclusive upper bounds and stores it in the specified variable.<br>*minValue*: The inclusive lower bound of the random range.; *maxValue*: The exclusive upper bound of the random range.; *variableName*: The variable name to store the generated double value. |
| SetRandomNumberInRange | When a random integer between (.\*) and (.\*) is stored in variable '(.\*)' | When step: Generates a random integer within the inclusive lower/upper bounds and stores it in the specified variable.<br>*minValue*: The inclusive lower bound of the random range.; *maxValue*: The exclusive upper bound of the random range.; *variableName*: The variable name to store the generated integer value. |


<a id="class-randomstringvariablebindings"></a>
## Class: RandomStringVariableBindings
<br>            Step bindings for generating and storing random strings in scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetRandomString | When a random '(.\*)' string is stored in variable '(.\*)' | When step: Generates a random string based on the specified type and stores it in the given variable.<br>*stringType*: The category/type of random string to generate. Supported values:<br>            FirstName: A random first name.<br>            LastName: A random last name.<br>            FullName: A random full name.<br>            UserName: A random internet username.<br>            Email: A random email address.<br>            PhoneNumber: A random phone number.<br>            CompanyName: A random company name.<br>            JobTitle: A random job title.<br>            City: A random city name.<br>            Country: A random country name.<br>            StreetAddress: A random street address.<br>            ZipCode: A random ZIP/postal code.<br>            Url: A random internet URL.<br>            Word: A random lorem word.<br>            Sentence: A random lorem sentence.<br>            Ipv4: A random IPv4 address.<br>            Ipv6: A random IPv6 address.<br>            Guid: A random GUID.; *variableName*: The variable name to store the generated string value. |


<a id="class-setfromfile"></a>
## Class: SetFromFile
<br>            Step bindings to load the content of a file and store it into a scenario variable.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| LoadVariablesFile | Given the variables file '(.\*)' is loaded |  |
| SetVariableFromFile | When the content of file '(.\*)' is stored in variable '(.\*)' | When step: Reads all text from the specified file path and stores it into the given variable.<br>*filePath*: The path to the file to read.; *variableName*: The target variable name. |


<a id="class-stringoperationbindings"></a>
## Class: StringOperationBindings
<br>            Step bindings that perform string operations and store results in scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GetStringLength | When the length of string '(.\*)' is stored in variable '(.\*)' |  |
| GetSubString | When the substring from index '(.\*)' and length '(.\*)' is extracted from '(.\*)' and stored in variable '(.\*)' | When step: Extracts a substring from the provided input string using the given start index and length,<br>            then stores the result in the specified target variable.<br>*startIndex*: The zero-based starting index of the substring.; *length*: The number of characters to include in the substring.; *input*: The source string to extract from.; *targetVariableName*: The name of the variable where the substring will be stored. |

<a id="namespace-natlaresttestbindingsbindingsassertions"></a>
# Namespace: NatLaRestTest.Bindings.Bindings.Assertions

<a id="class-basicvariableassertions"></a>
## Class: BasicVariableAssertions
<br>            Step bindings providing basic assertions on scenario variables (null/not null).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableIsNotNull | Then the value of variable '(.\*)' is not null | Then step: Asserts that the specified variable is not null.<br>*variableName*: The name of the variable to check. |
| AssertVariableIsNull | Then the value of variable '(.\*)' is null | Then step: Asserts that the specified variable is null.<br>*variableName*: The name of the variable to check. |


<a id="class-collectionvariableassertions"></a>
## Class: CollectionVariableAssertions
<br>            Step bindings providing assertions for variables representing JSON arrays (element count checks).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertCollectionHasExactCount | Then the value of variable '(.\*)' has '(.\*)' elements | Then step: Asserts that the JSON array stored in the specified variable has exactly the given number of elements.<br>*variableName*: The variable name containing a JSON array string.; *count*: The expected number of elements. |
| AssertCollectionHasLessThanNElements | Then the value of variable '(.\*)' has less than '(.\*)' elements | Then step: Asserts that the JSON array stored in the specified variable has less than the given number of elements.<br>*variableName*: The variable name containing a JSON array string.; *count*: The threshold (exclusive) for element count. |
| AssertCollectionHasMoreThanNElements | Then the value of variable '(.\*)' has more than '(.\*)' elements | Then step: Asserts that the JSON array stored in the specified variable has more than the given number of elements.<br>*variableName*: The variable name containing a JSON array string.; *count*: The threshold (exclusive) for element count. |
| AssertCollectionIsEmpty | Then the value of variable '(.\*)' has no elements | Then step: Asserts that the JSON array stored in the specified variable has no elements.<br>*variableName*: The variable name containing a JSON array string. |
| AssertCollectionIsNotEmpty | Then the value of variable '(.\*)' has any elements | Then step: Asserts that the JSON array stored in the specified variable has at least one element.<br>*variableName*: The variable name containing a JSON array string. |


<a id="class-httpresponseassertionbindings"></a>
## Class: HttpResponseAssertionBindings
<br>            Step bindings providing assertions for the current HTTP response (status success, exact/not-equal status codes).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertResponseCode | Then the response code equals '(.\*)' | Then step: Asserts that the current HTTP response status code equals the expected value.<br>*code*: The expected HTTP status code (e.g., 200). |
| AssertResponseCodeIsNot | Then the response code does not equal '(.\*)' | Then step: Asserts that the current HTTP response status code does not equal the specified value.<br>*code*: The HTTP status code that must not match. |
| ResponseIsNotSuccess | Then the response does not indicate success | Then step: Asserts that the current HTTP response exists and does not indicate success. |
| ResponseIsSuccess | Then the response indicates success | Then step: Asserts that the current HTTP response exists and indicates success (2xx status). |


<a id="class-jsonschemaassertions"></a>
## Class: JsonSchemaAssertions
<br>            Step bindings providing JSON Schema validation assertions for JSON stored in scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableConformsToJsonSchema | Then the value of variable '(.\*)' matches the JSON schema: | Then step: Asserts that the JSON stored in the specified variable conforms to the provided JSON Schema.<br>*variableName*: The variable containing the JSON document to validate.; *jsonSchema*: The JSON Schema to validate against. |


<a id="class-numericvariablepathassertions"></a>
## Class: NumericVariablePathAssertions
<br>            Step bindings providing numeric assertions on variables that store numeric values.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| NumericVariableIsGreaterThan | Then the value of variable '(.\*)' is greater than '(.\*)' | Then step: Asserts that the numeric value stored in the specified variable is greater than the given value.<br>*variableName*: The variable name containing a numeric value.; *value*: The threshold value (exclusive). |
| NumericVariableIsLessThan | Then the value of variable '(.\*)' is less than '(.\*)' | Then step: Asserts that the numeric value stored in the specified variable is less than the given value.<br>*variableName*: The variable name containing a numeric value.; *value*: The threshold value (exclusive). |


<a id="class-regexassertions"></a>
## Class: RegExAssertions
<br>            Step bindings providing regular expression based assertions on scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableMatchesRegex | Then the value of variable '(.\*)' matches the regex pattern '(.\*)' | Then step: Asserts that the value of the specified variable matches the provided regular expression pattern.<br>*variableName*: The name of the variable whose value will be tested.; *pattern*: The regular expression pattern to match against. |


<a id="class-stringvariableassertions"></a>
## Class: StringVariableAssertions
<br>            Step bindings providing string-related assertions on scenario variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| StringVariableContains | Then the value of variable '(.\*)' contains '(.\*)' | Then step: Asserts that the specified variable's string value contains the given substring.<br>*variableName*: The variable to inspect.; *substring*: The expected substring. |
| StringVariableEndsWith | Then the value of variable '(.\*)' ends with '(.\*)' | Then step: Asserts that the specified variable's string value ends with the given suffix.<br>*variableName*: The variable to inspect.; *suffix*: The expected suffix. |
| StringVariableEquals | Then the value of variable '(.\*)' equals '(.\*)' | Then step: Asserts that the specified variable's string value equals the given comparison string.<br>*variableName*: The variable to inspect.; *comparison*: The expected value. |
| StringVariableIsEmpty | Then the value of variable '(.\*)' is empty | Then step: Asserts that the specified variable's string value is empty.<br>*variableName*: The variable to inspect. |
| StringVariableIsNotEmpty | Then the value of variable '(.\*)' is not empty | Then step: Asserts that the specified variable's string value is not empty.<br>*variableName*: The variable to inspect. |
| StringVariableLengthIs | Then the value of variable '(.\*)' is '(.\*)' characters long | Then step: Asserts that the length of the specified variable's string value equals the given length.<br>*variableName*: The variable to inspect.; *length*: The expected length. |
| StringVariableLengthIsLessThan | Then the value of variable '(.\*)' is less than '(.\*)' characters long | Then step: Asserts that the length of the specified variable's string value is less than the given length.<br>*variableName*: The variable to inspect.; *length*: The threshold length (exclusive). |
| StringVariableLengthIsMoreThan | Then the value of variable '(.\*)' is more than '(.\*)' characters long | Then step: Asserts that the length of the specified variable's string value is greater than the given length.<br>*variableName*: The variable to inspect.; *length*: The threshold length (exclusive). |
| StringVariableNotContains | Then the value of variable '(.\*)' does not contain '(.\*)' | Then step: Asserts that the specified variable's string value does not contain the given substring.<br>*variableName*: The variable to inspect.; *substring*: The substring that must not be present. |
| StringVariableNotEndsWith | Then the value of variable '(.\*)' does not end with '(.\*)' | Then step: Asserts that the specified variable's string value does not end with the given suffix.<br>*variableName*: The variable to inspect.; *suffix*: The suffix that must not match. |
| StringVariableNotEquals | Then the value of variable '(.\*)' does not equal '(.\*)' | Then step: Asserts that the specified variable's string value does not equal the given comparison string.<br>*variableName*: The variable to inspect.; *comparison*: The value that must not match. |
| StringVariableNotStartsWith | Then the value of variable '(.\*)' does not start with '(.\*)' | Then step: Asserts that the specified variable's string value does not start with the given prefix.<br>*variableName*: The variable to inspect.; *prefix*: The prefix that must not match. |
| StringVariableStartsWith | Then the value of variable '(.\*)' starts with '(.\*)' | Then step: Asserts that the specified variable's string value starts with the given prefix.<br>*variableName*: The variable to inspect.; *prefix*: The expected prefix. |

<a id="namespace-natlaresttestbindingsbindingsassertionsjsonpath"></a>
# Namespace: NatLaRestTest.Bindings.Bindings.Assertions.JsonPath

<a id="class-basicvariablejsonpathassertions"></a>
## Class: BasicVariableJsonPathAssertions
<br>            Step bindings providing basic string equality/inequality assertions against values resolved via JSONPath from a JSON variable.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertValueEquals | Then the value of JSONPath '(.\*)' in variable '(.\*)' equals '(.\*)' | Then step: Asserts that the value selected by the provided JSONPath from the specified variable equals the given comparison string.<br>*jsonPath*: The JSONPath expression used to select a value.; *variable*: The name of the variable containing a JSON string to evaluate.; *comparison*: The expected string value to compare against the selected value. |
| AssertValueNotEquals | Then the value of JSONPath '(.\*)' in variable '(.\*)' does not equal '(.\*)' | Then step: Asserts that the value selected by the provided JSONPath from the specified variable does not equal the given comparison string.<br>*jsonPath*: The JSONPath expression used to select a value.; *variable*: The name of the variable containing a JSON string to evaluate.; *comparison*: The string value that must not match the selected value. |


<a id="class-collectionvariablejsonpathassertions"></a>
## Class: CollectionVariableJsonPathAssertions
<br>            Step bindings providing assertions for JSON arrays resolved via JSONPath from JSON variables (element count checks).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertCollectionHasExactCount | Then the value of JSONPath '(.\*)' in variable '(.\*)' has '(.\*)' elements | Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has exactly the provided number of elements.<br>*jsonPath*: The JSONPath expression selecting the array.; *variableName*: The variable name containing a JSON value.; *count*: The expected number of elements. |
| AssertCollectionHasLessThanNElements | Then the value of JSONPath '(.\*)' in variable '(.\*)' has less than '(.\*)' elements | Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has less than the provided number of elements.<br>*jsonPath*: The JSONPath expression selecting the array.; *variableName*: The variable name containing a JSON value.; *count*: The exclusive upper bound for the number of elements. |
| AssertCollectionHasMoreThanNElements | Then the value of JSONPath '(.\*)' in variable '(.\*)' has more than '(.\*)' elements | Then step: Asserts that the JSON array selected by the given JSONPath in the specified variable has more than the provided number of elements.<br>*jsonPath*: The JSONPath expression selecting the array.; *variableName*: The variable name containing a JSON value.; *count*: The exclusive lower bound for the number of elements. |
| AssertCollectionIsEmpty | Then the value of JSONPath '(.\*)' in variable '(.\*)' has no elements | Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with no elements.<br>*jsonPath*: The JSONPath expression selecting the array.; *variableName*: The variable name containing a JSON value. |
| AssertCollectionIsNotEmpty | Then the value of JSONPath '(.\*)' in variable '(.\*)' has any elements | Then step: Asserts that the value at the given JSONPath in the specified variable is a JSON array with at least one element.<br>*jsonPath*: The JSONPath expression selecting the array.; *variableName*: The variable name containing a JSON value. |


<a id="class-numericvariablejsonpathassertions"></a>
## Class: NumericVariableJsonPathAssertions
<br>            Step bindings providing numeric comparison assertions for values resolved by JSONPath from JSON variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| NumericVariableIsGreaterThan | Then the value of JSONPath '(.\*)' in variable '(.\*)' is greater than '(.\*)' | Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is greater than the given value.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *value*: The threshold value (exclusive). |
| NumericVariableIsLessThan | Then the value of JSONPath '(.\*)' in variable '(.\*)' is less than '(.\*)' | Then step: Asserts that the numeric value extracted by JSONPath from the specified variable is less than the given value.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *value*: The threshold value (exclusive). |


<a id="class-stringvariablejsonpathassertions"></a>
## Class: StringVariableJsonPathAssertions
<br>            Step bindings providing string-based assertions on values resolved by JSONPath from JSON variables.<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| StringVariableContains | Then the value of JSONPath '(.\*)' in variable '(.\*)' contains '(.\*)' | Then step: Asserts that the value extracted by JSONPath from the specified variable contains the given substring.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *comparison*: The substring expected to be contained. |
| StringVariableEndsWith | Then the value of JSONPath '(.\*)' in variable '(.\*)' ends with '(.\*)' | Then step: Asserts that the extracted value ends with the specified suffix.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *comparison*: The expected suffix. |
| StringVariableIsEmpty | Then the value of JSONPath '(.\*)' in variable '(.\*)' is empty | Then step: Asserts that the extracted value is empty.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON. |
| StringVariableIsLength | Then the value of JSONPath '(.\*)' in variable '(.\*)' is '(.\*)' characters long | Then step: Asserts that the extracted value length equals the specified number of characters.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *length*: The expected length in characters. |
| StringVariableIsLessThanLength | Then the value of JSONPath '(.\*)' in variable '(.\*)' is less than '(.\*)' characters long | Then step: Asserts that the extracted value length is less than the specified number of characters.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *length*: The threshold length (exclusive). |
| StringVariableIsMoreThanLength | Then the value of JSONPath '(.\*)' in variable '(.\*)' is more than '(.\*)' characters long | Then step: Asserts that the extracted value length is greater than the specified number of characters.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *length*: The threshold length (exclusive). |
| StringVariableIsNotEmpty | Then the value of JSONPath '(.\*)' in variable '(.\*)' is not empty | Then step: Asserts that the extracted value is not empty.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON. |
| StringVariableNotContains | Then the value of JSONPath '(.\*)' in variable '(.\*)' does not contain '(.\*)' | Then step: Asserts that the value extracted by JSONPath from the specified variable does not contain the given substring.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *comparison*: The substring that must not be contained. |
| StringVariableNotEndsWith | Then the value of JSONPath '(.\*)' in variable '(.\*)' does not end with '(.\*)' | Then step: Asserts that the extracted value does not end with the specified suffix.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *comparison*: The suffix that must not match. |
| StringVariableNotStartsWith | Then the value of JSONPath '(.\*)' in variable '(.\*)' does not start with '(.\*)' | Then step: Asserts that the extracted value does not start with the specified prefix.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *comparison*: The prefix that must not match. |
| StringVariableStartsWith | Then the value of JSONPath '(.\*)' in variable '(.\*)' starts with '(.\*)' | Then step: Asserts that the extracted value starts with the specified prefix.<br>*jsonPath*: The JSONPath expression.; *variableName*: The variable name containing JSON.; *comparison*: The expected prefix. |

<a id="namespace-natlaresttestbindingsbindingssetup"></a>
# Namespace: NatLaRestTest.Bindings.Bindings.Setup

<a id="class-httpclientconfigurationbindings"></a>
## Class: HttpClientConfigurationBindings
<br>            Step bindings to configure the shared HTTP client used across scenarios (base URL, timeout, headers).<br>            <br>

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| DisableSslCertificateValidation | Given SSL certificate validation is disabled | Given step: Disables SSL certificate validation for outgoing requests. |
| SetBaseUrl | Given the base URL '(.\*)' | Given step: Configures the base address used by the shared HTTP client.<br>*baseUrl*: The absolute base URL (e.g., https://api.example.com). |
| SetDefaultHeader | Given the default header '(.\*)' with value '(.\*)' | Given step: Adds a default request header to the shared HTTP client.<br>*headerName*: The name of the header to add.; *headerValue*: The value of the header. |
| SetDefaultTimeout | Given the default timeout of '(.\*)' seconds | Given step: Sets the default timeout for HTTP requests executed by the shared HTTP client.<br>*seconds*: The timeout value in seconds. |

