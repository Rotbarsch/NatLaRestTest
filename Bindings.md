## Table of Contents
- [Namespace: NatLaRestTest.Bindings](#namespace-natlaresttestbindings)
  - [Class: BasicVariableAssertions](#class-basicvariableassertions)
  - [Class: BasicVariableBindings](#class-basicvariablebindings)
  - [Class: BoolVariableAssertions](#class-boolvariableassertions)
  - [Class: CollectionVariableAssertions](#class-collectionvariableassertions)
  - [Class: DateTimeVariableBindings](#class-datetimevariablebindings)
  - [Class: DateTimeVariableManipulationBindings](#class-datetimevariablemanipulationbindings)
  - [Class: HttpClientConfigurationBindings](#class-httpclientconfigurationbindings)
  - [Class: HttpClientRequestBindings](#class-httpclientrequestbindings)
  - [Class: HttpClientRequestStreamBindings](#class-httpclientrequeststreambindings)
  - [Class: HttpResponseAssertionBindings](#class-httpresponseassertionbindings)
  - [Class: HttpResponseStreamBindings](#class-httpresponsestreambindings)
  - [Class: HttpResponseVariableBindings](#class-httpresponsevariablebindings)
  - [Class: JsonPathBindings](#class-jsonpathbindings)
  - [Class: JsonPathCollectionFilterBindings](#class-jsonpathcollectionfilterbindings)
  - [Class: JsonSchemaAssertions](#class-jsonschemaassertions)
  - [Class: NumericVariableAssertions](#class-numericvariableassertions)
  - [Class: NumericVariableManipulationBindings](#class-numericvariablemanipulationbindings)
  - [Class: RandomNumberVariableBindings](#class-randomnumbervariablebindings)
  - [Class: RandomStringVariableBindings](#class-randomstringvariablebindings)
  - [Class: RegExAssertions](#class-regexassertions)
  - [Class: SetFromFileBindings](#class-setfromfilebindings)
  - [Class: StopwatchBindings](#class-stopwatchbindings)
  - [Class: StringOperationBindings](#class-stringoperationbindings)
  - [Class: StringVariableAssertions](#class-stringvariableassertions)
  - [Class: StringVariableManipulationBindings](#class-stringvariablemanipulationbindings)
  - [Class: VariableXmlBindings](#class-variablexmlbindings)
  - [Class: WaitBindings](#class-waitbindings)

<a id="namespace-natlaresttestbindings"></a>
# Namespace: NatLaRestTest.Bindings

<a id="class-natlaresttestbindingsactionsbasicvariablebindings"></a>
## Class: NatLaRestTest.Bindings.Actions.BasicVariableBindings

Step bindings for setting scenario variables to explicit string values (single line or multiline).

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetVariableManually | When the value '(.\*)' is stored in variable '(.\*)' | When step: Sets the specified scenario variable to the provided string value.<br>            Set variables can be resolved in every binding parameter (multi-line or enclosed in single quotes) using the syntax: \\$(variableName).<br>*value*: The value to assign to the variable.<br>*variableName*: The name of the variable to set. |
| SetVariableManuallyMultiline | When the following value is stored in variable '(.\*)': | When step: Sets the specified scenario variable to the provided multiline string value.<br>            Set variables can be resolved in every binding parameter (multi-line or enclosed in single quotes) using the syntax: \\$(variableName).<br>*variableName*: The name of the variable to set.<br>*value*: The value to assign to the variable. |
| SetVariableNull | When the value of variable '(.\*)' is set to null | When step: Sets the specified scenario variable to null.<br>*variableName*: The name of the variable to set. |


<a id="class-natlaresttestbindingsactionshttpclientrequestbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.HttpClientRequestBindings

Step bindings for issuing HTTP requests with the shared HTTP client (GET and generic verbs, with/without body).

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SendRequestWithBodyWithContentType | When a '(.\*)' request to '(.\*)' is made with content type '(.\*)' and the following request body: | When step: Sends an HTTP request with the specified method, content type, and request body to the relative path.<br>*httpMethod*: The HTTP method (e.g., POST or PUT).<br>*relativePath*: The relative path for the request.<br>*contentType*: The content type to set (e.g., "application/json").<br>*requestBody*: The raw request body payload. |
| SendRequestWithBodyWithoutContentType | When a '(.\*)' request to '(.\*)' is made with the following request body: | When step: Sends an HTTP request with the specified method and request body to the relative path. Uses the default<br>                content type "application/json".<br>*httpMethod*: The HTTP method (e.g., POST or PUT).<br>*relativePath*: The relative path for the request.<br>*requestBody*: The raw request body payload. |
| SendRequestWithoutBody | When a '(.\*)' request to '(.\*)' is made | When step: Sends an HTTP request with the specified method to the relative path without a request body.<br>*httpMethod*: The HTTP method (e.g., GET, POST, PUT, DELETE).<br>*relativePath*: The relative path for the request. |


<a id="class-natlaresttestbindingsactionshttpclientrequeststreambindings"></a>
## Class: NatLaRestTest.Bindings.Actions.HttpClientRequestStreamBindings

Step bindings for uploading files as stream content in HTTP requests.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| UploadFile | When a '(.\*)' request is made to '(.\*)' with the contents of file '(.\*)' as stream content | When step: Sends an HTTP request and uploads the contents of a file as stream content.<br>*httpMethod*: The HTTP method (e.g., POST, PUT).<br>*url*: The absolute or relative URL to request.<br>*fileName*: The path to the file whose contents will be uploaded. |
| UploadFile | When a '(.\*)' request is made to '(.\*)' with the contents of file '(.\*)' as stream content with content type '(.\*)' | When step: Sends an HTTP request and uploads the contents of a file as stream content with an explicit content<br>                type.<br>*httpMethod*: The HTTP method (e.g., POST, PUT).<br>*url*: The absolute or relative URL to request.<br>*fileName*: The path to the file whose contents will be uploaded.<br>*contentType*: The content type for the stream part. |


<a id="class-natlaresttestbindingsactionshttpresponsestreambindings"></a>
## Class: NatLaRestTest.Bindings.Actions.HttpResponseStreamBindings

Step bindings for working with HTTP response streams, including saving to a file and storing the stream length.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SaveResponseStreamToFile | When the response stream is saved to file '(.\*)' | When step: Saves the current response stream to a file.<br>*filePath*: The target file path. |
| StoreResponseStreamLengthInVariable | When the length of the response stream is stored in variable '(.\*)' | When step: Stores the length of the current response stream (in bytes) into a scenario variable.<br>*variableName*: The target variable name. |


<a id="class-natlaresttestbindingsactionshttpresponsevariablebindings"></a>
## Class: NatLaRestTest.Bindings.Actions.HttpResponseVariableBindings

Step bindings for storing parts of the HTTP response (e.g., body) into scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| StoreResponseBody | When the response body is stored in variable '(.\*)' | When step: Stores the body of the current HTTP response as a string in the specified variable. Asserts that a<br>                response is available.<br>*variableName*: The name of the variable to store the response body. |
| StoreResponseHeaderValue | When the value of header '(.\*)' is stored in variable '(.\*)' | When step: Stores the value of the specified response header into a scenario variable.<br>*headerName*: The response header to read.<br>*variableName*: The target variable name. |
| StoreResponseTime | When the response time is stored in variable '(.\*)' | When step: Stores the response time (in milliseconds) of the current HTTP response into a scenario variable.<br>*variableName*: |


<a id="class-natlaresttestbindingsactionsjsonpathbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.JsonPathBindings

Step bindings for extracting values from JSON variables using JSONPath and storing them in scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetVariableFromJsonPath | When the value of JSONPath '(.\*)' in variable '(.\*)' is stored in variable '(.\*)' | When step: Extracts a value from a JSON variable via JSONPath and stores it as a new variable (stringified).<br>*jPath*: The JSONPath expression to evaluate.<br>*sourceVariableName*: The name of the source variable containing JSON.<br>*targetVariableName*: The name of the variable to set with the extracted value. |


<a id="class-natlaresttestbindingsactionsjsonpathcollectionfilterbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.JsonPathCollectionFilterBindings

Step bindings to filter JSON collections by evaluating JSONPath expressions against elements and applying comparison operations.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| FilterCollectionByJPathDoesNotEqual | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' does not equal '(.\*)' is stored in variable '(.\*)' | Filters the collection where the JSONPath value does not equal the comparison value.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*comparisonValue*: The value to compare against (as string).<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathEquals | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' equals '(.\*)' is stored in variable '(.\*)' | Filters the collection where the JSONPath value equals the comparison value.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*comparisonValue*: The value to compare against (as string).<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathGreaterThan | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is greater than '(.\*)' is stored in variable '(.\*)' | Filters the collection in the source variable by selecting elements where the JSONPath value is greater than the comparison value.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*comparisonValue*: The value to compare against (as string).<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathHasElements | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' has elements is stored in variable '(.\*)' | Filters the collection where the JSONPath value is a collection with elements.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathHasNoElements | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' has no elements is stored in variable '(.\*)' | Filters the collection where the JSONPath value is a collection with no elements.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathIsEmpty | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is empty is stored in variable '(.\*)' | Filters the collection where the JSONPath value is empty.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathIsFalse | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is false is stored in variable '(.\*)' | Filters the collection where the JSONPath value is boolean false.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathIsNotEmpty | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is not empty is stored in variable '(.\*)' | Filters the collection where the JSONPath value is not empty.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathIsNotNull | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is not null is stored in variable '(.\*)' | Filters the collection where the JSONPath value is not null.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathIsNull | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is null is stored in variable '(.\*)' | Filters the collection where the JSONPath value is null.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathIsTrue | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is true is stored in variable '(.\*)' | Filters the collection where the JSONPath value is boolean true.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*targetVariableName*: The variable to store the filtered collection into. |
| FilterCollectionByJPathLessThan | When each element of collection in variable '(.\*)' where the value of JSONPath '(.\*)' is less than '(.\*)' is stored in variable '(.\*)' | Filters the collection where the JSONPath value is less than the comparison value.<br>*sourceVariableName*: The name of the variable containing the JSON collection.<br>*jPath*: The JSONPath expression evaluated against each element.<br>*comparisonValue*: The value to compare against (as string).<br>*targetVariableName*: The variable to store the filtered collection into. |


<a id="class-natlaresttestbindingsactionsmanipulatevariableactionsdatetimevariablemanipulationbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.ManipulateVariableActions.DateTimeVariableManipulationBindings

Step bindings for manipulating existing DateTime variables by adding or subtracting a TimeSpan, and computing
                differences.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AddTimeSpanToVariable | When the timespan '(.\*)' is added to the value of variable '(.\*)' | When step: Adds the provided timespan to the current DateTime value stored in the specified variable.<br>*timeSpan*: The timespan to add (e.g., "01:30:00" for 1h30m).<br>*variableName*: The target variable name. |
| SaveFormattedDateTime | When the date '(.\*)' is stored in variable '(.\*)' in format '(.\*)' | When steps: Formats a datetime and stores the resulting string in a specified variable.<br>*dateTime*: Input datetime.<br>*targetVariableName*: Variable to store the result in.<br>*format*: .NET format of the string, eg. YYMMDD |
| SubtractTimeSpanFromVariable | When the timespan '(.\*)' is subtracted from the value of variable '(.\*)' | When step: Subtracts the provided timespan from the current DateTime value stored in the specified variable.<br>*timeSpan*: The timespan to subtract.<br>*variableName*: The target variable name. |


<a id="class-natlaresttestbindingsactionsmanipulatevariableactionsnumericvariablemanipulationbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.ManipulateVariableActions.NumericVariableManipulationBindings

Step bindings for manipulating existing numeric variables by applying arithmetic operations.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AddNumberToVariable | When the number '(.\*)' is added to the value of variable '(.\*)' | When step: Adds the provided number to the current numeric value stored in the specified variable.<br>*number*: The number to add.<br>*variableName*: The target variable name. |
| DivideVariableByNumber | When the value of variable '(.\*)' is divided by the number '(.\*)' | When step (inverse of above): Divides the current numeric value stored in the specified variable by the provided<br>                number (variable / number).<br>*variableName*: The variable containing the dividend.<br>*number*: The divisor. |
| MultiplyNumberWithVariable | When the value of variable '(.\*)' is multiplied with the number '(.\*)' | When step: Multiplies the provided number with the current numeric value stored in the specified variable.<br>*variableName*: The target variable name.<br>*number*: The number to multiply with. |
| SubtractNumberFromVariable | When the number '(.\*)' is subtracted from the value of variable '(.\*)' | When step: Subtracts the provided number from the current numeric value stored in the specified variable (variable<br>                - number).<br>*number*: The number to subtract.<br>*variableName*: The target variable name. |


<a id="class-natlaresttestbindingsactionsmanipulatevariableactionsstringvariablemanipulationbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.ManipulateVariableActions.StringVariableManipulationBindings

Step bindings for manipulating existing string variables by appending, prepending, or replacing content.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AppendStringToVariable | When the string '(.\*)' is appended to the value of variable '(.\*)' | When step: Appends a literal string to the end of the specified variable's current value.<br>*valueToAppend*: The string to append.<br>*variableName*: The target variable name. |
| PrependStringToVariable | When the string '(.\*)' is prepended to the value of variable '(.\*)' | When step: Prepends a literal string to the beginning of the specified variable's current value.<br>*valueToPrepend*: The string to prepend.<br>*variableName*: The target variable name. |
| ReplaceStringInVariable | When the string '(.\*)' is replaced with '(.\*)' in the value of variable '(.\*)' | When step: Replaces all occurrences of a substring with another within the specified variable's value.<br>*oldValue*: The substring to replace.<br>*newValue*: The replacement string.<br>*variableName*: The target variable name. |


<a id="class-natlaresttestbindingsactionssetvariableactionsdatetimevariablebindings"></a>
## Class: NatLaRestTest.Bindings.Actions.SetVariableActions.DateTimeVariableBindings

Step bindings for storing date/time based values into scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetCurrentDate | When ^the current date is stored in variable '([^']+)'\\$ | When step: Stores the current date/time as a string in the specified variable using the system default format.<br>*variableName*: The variable name to store the current date/time into. |
| SetCurrentDateFormatted | When ^the current date is stored in variable '([^']+)' in format '([^']+)'\\$ | When step: Stores the current date/time as a string in the specified variable using the provided .NET date/time<br>                format string.<br>*variableName*: The variable name to store the formatted date/time into.<br>*dateFormat*: A .NET date/time format string (e.g., "yyyy-MM-dd"). |


<a id="class-natlaresttestbindingsactionssetvariableactionsrandomnumbervariablebindings"></a>
## Class: NatLaRestTest.Bindings.Actions.SetVariableActions.RandomNumberVariableBindings

Step bindings for generating and storing random numeric values in scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetRandomDoubleInRange | When a random double between '(.\*)' and '(.\*)' is stored in variable '(.\*)' | When step: Generates a random double within the inclusive lower and exclusive upper bounds and stores it in the<br>                specified variable.<br>*minValue*: The inclusive lower bound of the random range.<br>*maxValue*: The exclusive upper bound of the random range.<br>*variableName*: The variable name to store the generated double value. |
| SetRandomNumberInRange | When a random integer between '(.\*)' and '(.\*)' is stored in variable '(.\*)' | When step: Generates a random integer within the inclusive lower/upper bounds and stores it in the specified<br>                variable.<br>*minValue*: The inclusive lower bound of the random range.<br>*maxValue*: The exclusive upper bound of the random range.<br>*variableName*: The variable name to store the generated integer value. |


<a id="class-natlaresttestbindingsactionssetvariableactionsrandomstringvariablebindings"></a>
## Class: NatLaRestTest.Bindings.Actions.SetVariableActions.RandomStringVariableBindings

Step bindings for generating and storing random strings in scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetRandomString | When a random '(.\*)' string is stored in variable '(.\*)' | When step: Generates a random string based on the specified type and stores it in the given variable.<br>*stringType*: The category/type of random string to generate. Supported values:<br>                FirstName: A random first name.<br>                LastName: A random last name.<br>                FullName: A random full name.<br>                UserName: A random internet username.<br>                Email: A random email address.<br>                PhoneNumber: A random phone number.<br>                CompanyName: A random company name.<br>                JobTitle: A random job title.<br>                City: A random city name.<br>                Country: A random country name.<br>                StreetAddress: A random street address.<br>                ZipCode: A random ZIP/postal code.<br>                Url: A random internet URL.<br>                Word: A random lorem word.<br>                Sentence: A random lorem sentence.<br>                Ipv4: A random IPv4 address.<br>                Ipv6: A random IPv6 address.<br>                Guid: A random GUID.<br>*variableName*: The variable name to store the generated string value. |


<a id="class-natlaresttestbindingsactionssetvariableactionssetfromfilebindings"></a>
## Class: NatLaRestTest.Bindings.Actions.SetVariableActions.SetFromFileBindings

Step bindings to load the content of a file and store it into a scenario variable.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| LoadVariablesFile | Given the variables file '(.\*)' is loaded | Given step: Loads variables from a JSON file into the variable storage.<br>*filePath*: Path to the variables JSON file. |
| SetVariableFromFile | When the content of file '(.\*)' is stored in variable '(.\*)' | When step: Reads all text from the specified file path and stores it into the given variable.<br>*filePath*: The path to the file to read.<br>*variableName*: The target variable name. |


<a id="class-natlaresttestbindingsactionssetvariableactionsstringoperationbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.SetVariableActions.StringOperationBindings

Step bindings that perform string operations and store results in scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| GetStringLength | When the length of string '(.\*)' is stored in variable '(.\*)' | When step: Stores the length of the given input string in the specified target variable.<br>*input*: The input string to measure.<br>*targetVariableName*: The name of the variable where the length will be stored. |
| GetSubString | When the substring from index '(.\*)' and length '(.\*)' is extracted from '(.\*)' and stored in variable '(.\*)' | When step: Extracts a substring from the provided input string using the given start index and length,<br>                then stores the result in the specified target variable.<br>*startIndex*: The zero-based starting index of the substring.<br>*length*: The number of characters to include in the substring.<br>*input*: The source string to extract from.<br>*targetVariableName*: The name of the variable where the substring will be stored. |


<a id="class-natlaresttestbindingsactionsstopwatchbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.StopwatchBindings

Step bindings for Stopwatch setup.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| Resume | When the stopwatch '(.\*)' is resumed | When step: Pauses the stopwatch with the specified name.<br>*name*: Name of the stopwatch to resume. |
| Start | When a stopwatch named '(.\*)' is started | When step: Creates and starts a new stopwatch with the specified name.<br>*name*: Name of the stopwatch to create. |
| Stop | When the stopwatch '(.\*)' is stopped | When step: Stops the stopwatch with the specified name.<br>*name*: Name of the stopwatch to stop. |
| StoreElapsedInVariable | When the elapsed time of stopwatch '(.\*)' is stored in variable '(.\*)' | Stores the elapsed time of the specified stopwatch in a variable for later use in the test.<br>*stopwatchName*: The name of the stopwatch whose elapsed time is to be retrieved.<br>*targetVariableName*: The name of the variable in which to store the elapsed time. |


<a id="class-natlaresttestbindingsactionsvariablexmlbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.VariableXmlBindings

Step bindings for extracting values from XML using XPath and storing them in scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| SetVariableFromXPath | When the result of XPath '(.\*)' in the value of variable '(.\*)' is stored in variable '(.\*)' | When step: Evaluates the given XPath expression against XML stored in <br>            and stores the resulting node/attribute string value in .<br>*xPath*: The XPath expression to evaluate.<br>*sourceVariableName*: The name of the variable containing XML to evaluate.<br>*targetVariableName*: The name of the variable where the extracted value will be stored. |


<a id="class-natlaresttestbindingsactionswaitbindings"></a>
## Class: NatLaRestTest.Bindings.Actions.WaitBindings

Step bindings for pausing test execution.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| Wait | When test execution is paused for '(.\*)' seconds | When step: Pauses test execution for the specified number of seconds.<br>*secondsToWait*: Amount of seconds to wait. |


<a id="class-natlaresttestbindingsassertionsbasicvariableassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.BasicVariableAssertions

Step bindings providing basic assertions on scenario variables (null/not null).

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableIsNotNull | Then the value of variable '(.\*)' is not null | Then step: Asserts that the specified variable is not null.<br>*variableName*: The name of the variable to check. |
| AssertVariableIsNull | Then the value of variable '(.\*)' is null | Then step: Asserts that the specified variable is null.<br>*variableName*: The name of the variable to check. |


<a id="class-natlaresttestbindingsassertionsboolvariableassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.BoolVariableAssertions

Step bindings providing assertions for boolean scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableIsFalse | Then the value of variable '(.\*)' is false | Then step: Asserts that the specified variable is false.<br>            Example usage: Then the value of variable 'featureEnabled' is false<br>*variableName*: The name of the variable to check. |
| AssertVariableIsTrue | Then the value of variable '(.\*)' is true | Then step: Asserts that the specified variable is true.<br>            Example usage: Then the value of variable 'isAvailable' is true<br>*variableName*: The name of the variable to check. |


<a id="class-natlaresttestbindingsassertionscollectionvariableassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.CollectionVariableAssertions

Step bindings providing assertions for variables representing JSON arrays (element count checks).

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertCollectionHasExactCount | Then the value of variable '(.\*)' has '(.\*)' elements | Then step: Asserts that the JSON array stored in the specified variable has exactly the given number of elements.<br>*variableName*: The variable name containing a JSON array string.<br>*count*: The expected number of elements. |
| AssertCollectionHasLessThanNElements | Then the value of variable '(.\*)' has less than '(.\*)' elements | Then step: Asserts that the JSON array stored in the specified variable has less than the given number of elements.<br>*variableName*: The variable name containing a JSON array string.<br>*count*: The threshold (exclusive) for element count. |
| AssertCollectionHasMoreThanNElements | Then the value of variable '(.\*)' has more than '(.\*)' elements | Then step: Asserts that the JSON array stored in the specified variable has more than the given number of elements.<br>*variableName*: The variable name containing a JSON array string.<br>*count*: The threshold (exclusive) for element count. |
| AssertCollectionIsEmpty | Then the value of variable '(.\*)' has no elements | Then step: Asserts that the JSON array stored in the specified variable has no elements.<br>*variableName*: The variable name containing a JSON array string. |
| AssertCollectionIsNotEmpty | Then the value of variable '(.\*)' has any elements | Then step: Asserts that the JSON array stored in the specified variable has at least one element.<br>*variableName*: The variable name containing a JSON array string. |


<a id="class-natlaresttestbindingsassertionshttpresponseassertionbindings"></a>
## Class: NatLaRestTest.Bindings.Assertions.HttpResponseAssertionBindings

Step bindings providing assertions for the current HTTP response (status success, exact/not-equal status codes).

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertResponseCode | Then the response code equals '(.\*)' | Then step: Asserts that the current HTTP response status code equals the expected value.<br>*code*: The expected HTTP status code (e.g., 200). |
| AssertResponseCodeIsNot | Then the response code does not equal '(.\*)' | Then step: Asserts that the current HTTP response status code does not equal the specified value.<br>*code*: The HTTP status code that must not match. |
| ResponseIsNotSuccess | Then the response does not indicate success | Then step: Asserts that the current HTTP response exists and does not indicate success. |
| ResponseIsSuccess | Then the response indicates success | Then step: Asserts that the current HTTP response exists and indicates success (2xx status). |


<a id="class-natlaresttestbindingsassertionsjsonschemaassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.JsonSchemaAssertions

Step bindings providing JSON Schema validation assertions for JSON stored in scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableConformsToJsonSchema | Then the value of variable '(.\*)' matches the JSON schema: | Then step: Asserts that the JSON stored in the specified variable conforms to the provided JSON Schema.<br>*variableName*: The variable containing the JSON document to validate.<br>*jsonSchema*: The JSON Schema to validate against. |


<a id="class-natlaresttestbindingsassertionsnumericvariableassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.NumericVariableAssertions

Step bindings providing numeric assertions on variables that store numeric values.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| NumericVariableIsGreaterThan | Then the value of variable '(.\*)' is greater than '(.\*)' | Then step: Asserts that the numeric value stored in the specified variable is greater than the given value.<br>*variableName*: The variable name containing a numeric value.<br>*value*: The threshold value (exclusive). |
| NumericVariableIsLessThan | Then the value of variable '(.\*)' is less than '(.\*)' | Then step: Asserts that the numeric value stored in the specified variable is less than the given value.<br>*variableName*: The variable name containing a numeric value.<br>*value*: The threshold value (exclusive). |


<a id="class-natlaresttestbindingsassertionsregexassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.RegExAssertions

Step bindings providing regular expression based assertions on scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| AssertVariableDoesNotMatchRegex | Then the value of variable '(.\*)' does not match the regex pattern '(.\*)' | Then step: Asserts that the value of the specified variable does not match the provided regular expression pattern.<br>*variableName*: The name of the variable whose value will be tested.<br>*pattern*: The regular expression pattern to match against. |
| AssertVariableMatchesRegex | Then the value of variable '(.\*)' matches the regex pattern '(.\*)' | Then step: Asserts that the value of the specified variable matches the provided regular expression pattern.<br>*variableName*: The name of the variable whose value will be tested.<br>*pattern*: The regular expression pattern to match against. |


<a id="class-natlaresttestbindingsassertionsstringvariableassertions"></a>
## Class: NatLaRestTest.Bindings.Assertions.StringVariableAssertions

Step bindings providing string-related assertions on scenario variables.

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| StringVariableContains | Then the value of variable '(.\*)' contains: | Then step: Asserts that the specified variable's string value contains the given substring.<br>*variableName*: The variable to inspect.<br>*substring*: The expected substring. |
| StringVariableContains | Then the value of variable '(.\*)' contains '(.\*)' | Then step: Asserts that the specified variable's string value contains the given substring.<br>*variableName*: The variable to inspect.<br>*substring*: The expected substring. |
| StringVariableEndsWith | Then the value of variable '(.\*)' ends with: | Then step: Asserts that the specified variable's string value ends with the given suffix.<br>*variableName*: The variable to inspect.<br>*suffix*: The expected suffix. |
| StringVariableEndsWith | Then the value of variable '(.\*)' ends with '(.\*)' | Then step: Asserts that the specified variable's string value ends with the given suffix.<br>*variableName*: The variable to inspect.<br>*suffix*: The expected suffix. |
| StringVariableEquals | Then the value of variable '(.\*)' equals: | Then step: Asserts that the specified variable's string value equals the given comparison string.<br>*variableName*: The variable to inspect.<br>*comparison*: The expected value. |
| StringVariableEquals | Then the value of variable '(.\*)' equals '(.\*)' | Then step: Asserts that the specified variable's string value equals the given comparison string.<br>*variableName*: The variable to inspect.<br>*comparison*: The expected value. |
| StringVariableIsEmpty | Then the value of variable '(.\*)' is empty | Then step: Asserts that the specified variable's string value is empty.<br>*variableName*: The variable to inspect. |
| StringVariableIsNotEmpty | Then the value of variable '(.\*)' is not empty | Then step: Asserts that the specified variable's string value is not empty.<br>*variableName*: The variable to inspect. |
| StringVariableNotContains | Then the value of variable '(.\*)' does not contain: | Then step: Asserts that the specified variable's string value does not contain the given substring.<br>*variableName*: The variable to inspect.<br>*substring*: The substring that must not be present. |
| StringVariableNotContains | Then the value of variable '(.\*)' does not contain '(.\*)' | Then step: Asserts that the specified variable's string value does not contain the given substring.<br>*variableName*: The variable to inspect.<br>*substring*: The substring that must not be present. |
| StringVariableNotEndsWith | Then the value of variable '(.\*)' does not end with: | Then step: Asserts that the specified variable's string value does not end with the given suffix.<br>*variableName*: The variable to inspect.<br>*suffix*: The suffix that must not match. |
| StringVariableNotEndsWith | Then the value of variable '(.\*)' does not end with '(.\*)' | Then step: Asserts that the specified variable's string value does not end with the given suffix.<br>*variableName*: The variable to inspect.<br>*suffix*: The suffix that must not match. |
| StringVariableNotEquals | Then the value of variable '(.\*)' does not equal: | Then step: Asserts that the specified variable's string value does not equal the given comparison string.<br>*variableName*: The variable to inspect.<br>*comparison*: The value that must not match. |
| StringVariableNotEquals | Then the value of variable '(.\*)' does not equal '(.\*)' | Then step: Asserts that the specified variable's string value does not equal the given comparison string.<br>*variableName*: The variable to inspect.<br>*comparison*: The value that must not match. |
| StringVariableNotStartsWith | Then the value of variable '(.\*)' does not start with: | Then step: Asserts that the specified variable's string value does not start with the given prefix.<br>*variableName*: The variable to inspect.<br>*prefix*: The prefix that must not match. |
| StringVariableNotStartsWith | Then the value of variable '(.\*)' does not start with '(.\*)' | Then step: Asserts that the specified variable's string value does not start with the given prefix.<br>*variableName*: The variable to inspect.<br>*prefix*: The prefix that must not match. |
| StringVariableStartsWith | Then the value of variable '(.\*)' starts with: | Then step: Asserts that the specified variable's string value starts with the given prefix.<br>*variableName*: The variable to inspect.<br>*prefix*: The expected prefix. |
| StringVariableStartsWith | Then the value of variable '(.\*)' starts with '(.\*)' | Then step: Asserts that the specified variable's string value starts with the given prefix.<br>*variableName*: The variable to inspect.<br>*prefix*: The expected prefix. |


<a id="class-natlaresttestbindingssetuphttpclientconfigurationbindings"></a>
## Class: NatLaRestTest.Bindings.Setup.HttpClientConfigurationBindings

Step bindings to configure the shared HTTP client used across scenarios (base URL, timeout, headers).

| MethodName | BindingValue | Comments |
|------------|--------------|----------|
| DisableSslCertificateValidation | Given SSL certificate validation is disabled | Given step: Disables SSL certificate validation for outgoing requests. |
| SetBaseUrl | Given the base URL '(.\*)' | Given step: Configures the base address used by the shared HTTP client.<br>*baseUrl*: The absolute base URL (e.g., https://api.example.com). |
| SetDefaultHeader | Given the default header '(.\*)' with value '(.\*)' | Given step: Adds a default request header to the shared HTTP client.<br>*headerName*: The name of the header to add.<br>*headerValue*: The value of the header. |
| SetDefaultTimeout | Given the default timeout of '(.\*)' seconds | Given step: Sets the default timeout for HTTP requests executed by the shared HTTP client.<br>*seconds*: The timeout value in seconds. |

