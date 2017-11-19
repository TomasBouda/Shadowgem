# Shadowgem [![NuGet](https://img.shields.io/nuget/v/TomLabs.Shadowgem.svg)](https://www.nuget.org/packages/TomLabs.Shadowgem/) [![Travis](https://travis-ci.org/TomasBouda/Shadowgem.svg?branch=master)](https://travis-ci.org/TomasBouda/Shadowgem) [![Join the chat at https://gitter.im/TomLabs_Shadowgem/Lobby](https://badges.gitter.im/TomLabs_Shadowgem/Lobby.svg)](https://gitter.im/TomLabs_Shadowgem/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
Library that provides extension and helper methods of all kinds.

## Install via NuGet

```
Install-Package TomLabs.Shadowgem -Version 1.0.0
```

## Generated documentation

## Type Win.Firewall

 Class provides methods for manipulating with windows firewall 



---
#### Method Win.Firewall.AllowAllInboundOnPort(System.Int32)

 Adds inbound rule to allow given `port` number 


|Name | Description |
|-----|------|
|port ||


---
## Type Win.CMD

 Windows command line helper class 



---
#### Method Win.CMD.RunCommand(System.String,System.String)

 Executes given command in windows command line 


|Name | Description |
|-----|------|
|arguments ||
|workingDirectory |directory context|

**Returns**: 



---
#### Method Win.CMD.MultipleChars(System.Char,System.Int32)

 Returns line of characters 


|Name | Description |
|-----|------|
|ch ||
|count ||

**Returns**: 



---
## Type Comparers.InlineComparer\<T\>

 Allows you to compare inline with linq query 


|Name | Description |
|-----|------|
|T ||


---
#### Method Comparers.InlineComparer\<T\>.#ctor(System.Func{\<T\>,\<T\>,System.Boolean},System.Func{\<T\>,System.Int32})

 Creates instance of [Comparers.InlineComparer\<T\>]()


|Name | Description |
|-----|------|
|equals |Pass lambda expression for comparison 

######  example

```cs
(t1, t2) => t1.Id == t2.Id
```

|
|hashCode |Pass lambda expression for GetHashCode function. 

######  example

```cs
i => i.Id.GetHashCode()
```

|


---
#### Method Comparers.InlineComparer\<T\>.Equals(\<T\>,\<T\>)




|Name | Description |
|-----|------|
|x ||
|y ||

**Returns**: 



---
#### Method Comparers.InlineComparer\<T\>.GetHashCode(\<T\>)




|Name | Description |
|-----|------|
|obj ||

**Returns**: 



---
## Type Enums.EnumHelper\<T\>

 Provides helper methods for [System.Enum]()


|Name | Description |
|-----|------|
|T ||


---
#### Method Enums.EnumHelper\<T\>.GetEnumDescription(System.String)

 Gets value of enum description attribute 


|Name | Description |
|-----|------|
|value ||

**Returns**: 



---
#### Method Enums.EnumHelper\<T\>.ToDictionary

 Converts given enum to dictionary 


**Returns**: 



---
## Type Extensions.CharExtensions

[System.Char]() related extension methods 



---
#### Method Extensions.CharExtensions.ToUpper(System.Char)

 Shortcut for [System.Char.ToUpper(System.Char)]()


|Name | Description |
|-----|------|
|ch ||

**Returns**: 



---
#### Method Extensions.CharExtensions.ToLower(System.Char)

 Shortcut for [System.Char.ToLower(System.Char)]()


|Name | Description |
|-----|------|
|ch ||

**Returns**: 



---
## Type Extensions.CommonExtensions

 CommonExtensions 



---
#### Method Extensions.CommonExtensions.OneOf\<T\>(System.Random,\<T\>[])

 Returns random element from given params collection 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|rnd ||
|things ||

**Returns**: 



---
#### Method Extensions.CommonExtensions.Match(System.String,System.String)

 Indicates whether the regular expression specified by `pattern` finds a match in a specified input [System.String](). 


|Name | Description |
|-----|------|
|value ||
|pattern ||

**Returns**:  `true`  if there is a match



---
#### Method Extensions.CommonExtensions.XmlSerialize\<T\>(\<T\>)

Serializes an object of type T in to an XML string


|Name | Description |
|-----|------|
|T |Any class type|

|Name | Description |
|-----|------|
|obj |Object to serialize|

**Returns**: A string that represents XML, empty otherwise



---
#### Method Extensions.CommonExtensions.XmlDeserialize\<T\>(System.String)

Deserializes an xml string into an object of Type T


|Name | Description |
|-----|------|
|T |Any class type|

|Name | Description |
|-----|------|
|xml |XML as string to deserialize from|

**Returns**: A new object of type T if successful, null if failed



---
#### Method Extensions.CommonExtensions.GetDefaultValue\<T\>(System.Nullable{\<T\>})

 Returns default value of given object 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|source ||

**Returns**: 



---
#### Method Extensions.CommonExtensions.ToCurrency(System.Double,System.String)

 Returns given [System.Decimal]() value formated as currency 


|Name | Description |
|-----|------|
|value ||
|cultureName ||

**Returns**: 



---
#### Method Extensions.CommonExtensions.IsNullOrEmpty\<T\>(\<T\>)

 Shortcut for [System.String.IsNullOrWhiteSpace(System.String)]()


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|obj ||

**Returns**: 



---
#### Method Extensions.CommonExtensions.DeepClone\<T\>(\<T\>)

 Makes a copy from the object. Doesn't copy the reference memory, only data. 


|Name | Description |
|-----|------|
|T |Type of the return object.|

|Name | Description |
|-----|------|
|item |Object to be copied.|

**Returns**: Returns the copied object.



---
#### Method Extensions.CommonExtensions.Clamp\<T\>(\<T\>,\<T\>,\<T\>)

 Limit a value to a certain range. When the value is smaller/bigger than the range, snap it to the range border. 


|Name | Description |
|-----|------|
|T |The type of the value to limit.|

|Name | Description |
|-----|------|
|source |The source for this extension method.|
|start |The start of the interval, included in the interval.|
|end |The end of the interval, included in the interval.|


---
#### Method Extensions.CommonExtensions.IsNull(System.Object)

`object` == null 


|Name | Description |
|-----|------|
|object ||

**Returns**: 



---
#### Method Extensions.CommonExtensions.IsDirectory(System.String)

 Returns  `true`  if given string is path to a directory 


|Name | Description |
|-----|------|
|path ||

**Returns**: 



---
#### Method Extensions.CommonExtensions.IsFile(System.String)

 Returns  `true`  if given string is path to a file 


|Name | Description |
|-----|------|
|path ||

**Returns**: 



---
## Type Extensions.DataTableExtensions

[System.Data.DataTable]() related extension methods 



---
## Type Extensions.DateTimeExtensions

[System.DateTime]() related extension methods http://extensionoverflow.codeplex.com/SourceControl/latest#ExtensionMethods 



---
#### Method Extensions.DateTimeExtensions.Elapsed(System.DateTime)

 Elapseds the time. 


|Name | Description |
|-----|------|
|datetime |The datetime.|

**Returns**: TimeSpan



---
#### Method Extensions.DateTimeExtensions.WeekOfYear(System.DateTime,System.Globalization.CalendarWeekRule,System.DayOfWeek)

 Weeks the of year. 


|Name | Description |
|-----|------|
|datetime |The datetime.|
|weekrule |The weekrule.|
|firstDayOfWeek |The first day of week.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.WeekOfYear(System.DateTime,System.DayOfWeek)

 Weeks the of year. 


|Name | Description |
|-----|------|
|datetime |The datetime.|
|firstDayOfWeek |The first day of week.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.WeekOfYear(System.DateTime,System.Globalization.CalendarWeekRule)

 Weeks the of year. 


|Name | Description |
|-----|------|
|datetime |The datetime.|
|weekrule |The weekrule.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.WeekOfYear(System.DateTime)

 Weeks the of year. 


|Name | Description |
|-----|------|
|datetime |The datetime.|
|weekrule |The weekrule.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.GetDateTimeForDayOfWeek(System.DateTime,System.DayOfWeek,System.DayOfWeek)

 Gets the date time for day of week. 


|Name | Description |
|-----|------|
|datetime |The datetime.|
|day |The day.|
|firstDayOfWeek |The first day of week.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.FirstDateTimeOfWeek(System.DateTime)

 Firsts the date time of week. 


|Name | Description |
|-----|------|
|datetime |The datetime.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.FirstDateTimeOfWeek(System.DateTime,System.DayOfWeek)

 Firsts the date time of week. 


|Name | Description |
|-----|------|
|datetime |The datetime.|
|firstDayOfWeek |The first day of week.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.DaysFromFirstDayOfWeek(System.DayOfWeek,System.DayOfWeek)

 Dayses from first day of week. 


|Name | Description |
|-----|------|
|current |The current.|
|firstDayOfWeek |The first day of week.|

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.IsWeekend(System.DateTime)

 Figure out if DateTime holds a date value that is a weekend 


|Name | Description |
|-----|------|
|value ||

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.Readable(System.DateTime)

 Returns given time as string formated to dd.MM.yyyy HH:mm:ss 


|Name | Description |
|-----|------|
|dateTime ||

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.ReadableMs(System.DateTime)

 Returns given time as string formated to dd.MM.yyyy HH:mm:ss:ms 


|Name | Description |
|-----|------|
|dateTime ||

**Returns**: 



---
#### Method Extensions.DateTimeExtensions.UnixTimeStampToDateTime(System.Double)

 Returns given unix timestamp as [System.DateTime]()


|Name | Description |
|-----|------|
|unixTimeStamp ||

**Returns**: 



---
## Type Extensions.EnumExtensions

 Enum related extension methods 



---
#### Method Extensions.EnumExtensions.GetDescription\<T\>(\<T\>,System.Type)

 Returns [System.ComponentModel.DescriptionAttribute]() value for enum 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|U ||

|Name | Description |
|-----|------|
|enumerationValue ||
|attributeType ||

**Returns**: 



---
#### Method Extensions.EnumExtensions.GetDescription\<T\>(\<T\>)

 Returns [System.ComponentModel.DescriptionAttribute]() value for enum 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|enumerationValue ||

**Returns**: 



---
#### Method Extensions.EnumExtensions.GetFlags(System.Enum)

 https://stackoverflow.com/questions/5542816/printing-flags-enum-as-separate-flags 


|Name | Description |
|-----|------|
|value ||

**Returns**: 



---
## Type Extensions.LinqExtensions

[System.Linq]() related extension methods 

 http://extensionoverflow.codeplex.com/SourceControl/latest#ExtensionMethods 



---
#### Method Extensions.LinqExtensions.ToCSVString(System.Linq.IOrderedQueryable)

 Converts the Linq data to a comma separated string including header. 


|Name | Description |
|-----|------|
|data |The data.|

**Returns**: 



---
#### Method Extensions.LinqExtensions.ToCSVString(System.Linq.IOrderedQueryable,System.String)

 Converts the Linq data to a comma separated string including header. 


|Name | Description |
|-----|------|
|data |The data.|
|delimiter |The delimiter.|

**Returns**: 



---
#### Method Extensions.LinqExtensions.ToCSVString(System.Linq.IOrderedQueryable,System.String,System.String)

 Converts the Linq data to a comma separated string including header. 


|Name | Description |
|-----|------|
|data |The data.|
|delimiter |The delimiter.|
|nullvalue |The null value.|

**Returns**: 



---
#### Method Extensions.LinqExtensions.ForEach\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Action{\<T\>})

 Shortcut for foreach statement 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|enum ||
|mapFunction ||


---
#### Method Extensions.LinqExtensions.OrderBy\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.String)

 Orders Enumerable using given sort expression Example: users.OrderBy("Name desc") 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|list ||
|sortExpression |Property and sort direction|

**Returns**: 



---
#### Method Extensions.LinqExtensions.Randomize\<T\>(System.Collections.Generic.IEnumerable{\<T\>})

 Returns randomly ordered Enumerable 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|target ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.ToCollection\<T\>(System.Collections.Generic.IEnumerable{\<T\>})

 Convert a [System.Collections.Generic.IEnumerable\<T\>]()to a [System.Collections.ObjectModel.Collection\<T\>]()


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|enumerable ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.OrderBy\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Func{\<T\>,\<T\>},System.Boolean)

[System.Linq.Enumerable.OrderBy\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Func{\<T\>,\<T\>})]() and [System.Linq.Enumerable.OrderByDescending\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Func{\<T\>,\<T\>})]() shortcut 


|Name | Description |
|-----|------|
|TSource ||

|Name | Description |
|-----|------|
|TKey ||

|Name | Description |
|-----|------|
|enumerable ||
|keySelector ||
|descending ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.OrderBy\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Func{\<T\>,System.IComparable},System.Func{\<T\>,System.IComparable},System.Func{\<T\>,System.IComparable}[])

 Order by multiple properties http://www.extensionmethod.net/csharp/ienumerable-t/orderby 


|Name | Description |
|-----|------|
|TSource ||

|Name | Description |
|-----|------|
|enumerable ||
|keySelector1 ||
|keySelector2 ||
|keySelectors ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.OrderBy\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Boolean,System.Func{\<T\>,System.IComparable},System.Func{\<T\>,System.IComparable}[])

 OrderBy by multiple properties http://www.extensionmethod.net/csharp/ienumerable-t/orderby 


|Name | Description |
|-----|------|
|TSource ||

|Name | Description |
|-----|------|
|enumerable ||
|descending |True if descending|
|keySelector ||
|keySelectors ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.Filter\<T\>(System.Collections.Generic.IEnumerable{\<T\>},System.Func{\<T\>,System.Boolean})

 Allows you to filter an [System.Collections.Generic.IEnumerable\<T\>]() http://www.extensionmethod.net/csharp/ienumerable-t/filter 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|list ||
|filterParam ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.Concat\<T\>(System.Collections.Generic.IEnumerable{\<T\>},\<T\>)

 Adds an element to an [System.Collections.Generic.IEnumerable\<T\>]()


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|target ||
|element ||

**Returns**: 



---
#### Method Extensions.LinqExtensions.JoinItems\<T\>(\<T\>,System.String)

 Concatenates the members of a constructed [System.Collections.Generic.IEnumerable\<T\>]() collection of type [System.String](), using the specified separator between each member. 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|collection ||
|separator ||

**Returns**: 



---
## Type Extensions.String.Encription.Hasher

 Provides methods for string hashing 



---
## Type Extensions.String.Encription.Hasher.eHashType

 Supported hash algorithms 



---
#### Field Extensions.String.Encription.Hasher.eHashType.SHA1

 https://www.howtogeek.com/238705/what-is-sha-1-and-why-will-retiring-it-kick-thousands-off-the-internet/ 



---
#### Method Extensions.String.Encription.Hasher.ComputeHash(System.String,TomLabs.Shadowgem.Extensions.String.Encription.Hasher.eHashType)

 Computes the hash of the string using a specified hash algorithm 


|Name | Description |
|-----|------|
|input |The string to hash|
|hashType |The hash algorithm to use|

**Returns**: The resulting hash or an empty string on error



---
## Type Extensions.String.Encription.StringEncrypt

 Provides methods for string encryption/decryption 



---
#### Method Extensions.String.Encription.StringEncrypt.Encrypt(System.String,System.String)

 Encrypts a string using the supplied key. Encoding is done using RSA encryption. 


|Name | Description |
|-----|------|
|stringToEncrypt |String that must be encrypted.|
|key |EncryptionKey.|

**Returns**: A string representing a byte array separated by a minus sign.

[[System.ArgumentException|System.ArgumentException]]: Occurs when stringToEncrypt or key is null or empty.



---
#### Method Extensions.String.Encription.StringEncrypt.Decrypt(System.String,System.String)

 Decrypts a string using the supplied key. Decoding is done using RSA encryption. 


|Name | Description |
|-----|------|
|key |DecryptionKey.|

**Returns**: The decrypted string or null if decryption failed.


|Name | Description |
|-----|------|
|stringToDecrypt ||
[[System.ArgumentException|System.ArgumentException]]: Occurs when stringToDecrypt or key is null or empty.



---
## Type Extensions.String.StringExtensions

 Provides extension methods applied to [System.String]()



---
#### Method Extensions.String.StringExtensions.Like(System.String,System.String)

 "SQL" Like function with that works with wildcards 


|Name | Description |
|-----|------|
|toSearch ||
|toFind ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.FillIn(System.String,System.Object[])

 String.Format shortcut 


|Name | Description |
|-----|------|
|s ||
|args |Arguments|

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToInt(System.String,System.Int32)

 Converts given string to [System.Int32]() or returns `defaultValue`


|Name | Description |
|-----|------|
|s ||
|defaultValue ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToIntN(System.String,System.Nullable{System.Int32})

 Converts given string to [System.Nullable]()[System.Int32]() or returns `defaultValue`


|Name | Description |
|-----|------|
|s ||
|defaultValue ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToDouble(System.String,System.Double)

 Converts given string to [System.Double]() or returns `defaultValue`


|Name | Description |
|-----|------|
|s ||
|defaultValue ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToFloat(System.String,System.Single)

 Converts given string to [System.Single]() or returns `defaultValue`


|Name | Description |
|-----|------|
|s ||
|defaultValue ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToDate(System.String,System.DateTime)

 Converts given string to [System.DateTime]() or returns `defaultValue`


|Name | Description |
|-----|------|
|s ||
|defaultValue ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.Parse\<T\>(System.String)

 Parse a string to any other type including nullable types using [System.ComponentModel.TypeConverter]()


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|value ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.MaxLength(System.String,System.Int32,System.String)

 Returns of given length. If length of given string is greater 


|Name | Description |
|-----|------|
|str ||
|maxLenght ||
|suffix ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.BetweenChars(System.String,System.Char,System.Char)

 Returns string located between two given characters 


|Name | Description |
|-----|------|
|str ||
|first ||
|last ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.EndsWith(System.String,System.String[],System.String,System.Boolean)

 Checks whether string ends with given sequence 


|Name | Description |
|-----|------|
|toSearch ||
|extension ||
|ignoreString ||
|ignoreCase ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToEnum\<T\>(System.String,System.Boolean)

 Converts string into enumerator of type [!:<T>]()


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|value ||
|ignoreCase ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.IsValidUrl(System.String)

 Determines whether given string is a valid URL. 


**Returns**:  `true`  if is valid URL otherwise returns  `false` . 



---
#### Method Extensions.String.StringExtensions.IsValidEmailAddress(System.String)

 Determines whether given string is a valid email address 


**Returns**:  `true`  if is valid email address otherwise returns  `false` . 



---
#### Method Extensions.String.StringExtensions.IsFilled(System.String)

 Inverse function of IsNullOrEmpty 


|Name | Description |
|-----|------|
|s ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ToUri(System.String)

 Returns given string as [System.Uri]()


|Name | Description |
|-----|------|
|s ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.IsNumber(System.String)

 Returns true if given string is an [System.Int32]()


|Name | Description |
|-----|------|
|s ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.CapitalizeSentence(System.String,System.String)

 Capitalizes all words in a given sentence 


|Name | Description |
|-----|------|
|s ||
|wordSeperator ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.CapitalizeWord(System.String)

 Capitalizes first character of given word 


|Name | Description |
|-----|------|
|s ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.SplitRgx(System.String,System.String,System.Text.RegularExpressions.RegexOptions)

 Shortcut for [System.Text.RegularExpressions.Regex.Split(System.String)]()


|Name | Description |
|-----|------|
|s ||
|pattern ||
|regexOptions ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.ReplaceRgx(System.String,System.String,System.String,System.Text.RegularExpressions.RegexOptions)

 Shortcut for [System.Text.RegularExpressions.Regex.Replace(System.String,System.String,System.String,System.Text.RegularExpressions.RegexOptions)]()


|Name | Description |
|-----|------|
|s ||
|pattern ||
|replacement ||
|regexOptions ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.RemoveWhitespaces(System.String)

 Removes all whitespace char from given string using [System.Text.RegularExpressions.Regex.Replace(System.String,System.String,System.String)]()


|Name | Description |
|-----|------|
|s ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.RemoveCZAccents(System.String)

 Replaces Czech accents characters in given string with neutral characters 


|Name | Description |
|-----|------|
|s ||

**Returns**: 



---
#### Method Extensions.String.StringExtensions.HtmlEncode(System.String)

 Converts to a HTML-encoded string 


|Name | Description |
|-----|------|
|data |The data.|

**Returns**: 



---
#### Method Extensions.String.StringExtensions.HtmlDecode(System.String)

 Converts the HTML-encoded string into a decoded string 



---
#### Method Extensions.String.StringExtensions.UrlEncode(System.String)

 Encode an Url string 



---
#### Method Extensions.String.StringExtensions.UrlDecode(System.String)

 Converts a string that has been encoded for transmission in a URL into a decoded string. 



---
## Type Extensions.XmlExtensions

 XML related extensions 



---
#### Method Extensions.XmlExtensions.Beautify(System.Xml.Linq.XDocument)

 Formats given XML document 


|Name | Description |
|-----|------|
|doc ||

**Returns**: 



---
## Type Files.FileHelper

 Provides methods for working with files 



---
#### Method Files.FileHelper.RemoveReadOnlyAttribute(System.String)

 Removes ReadOnly attribute on given file 


|Name | Description |
|-----|------|
|path ||


---
## Type Files.PathEx

 Provides extension methods for Path 



---
#### Method Files.PathEx.GoUp(System.String,System.Int32)

 Goes up in given `path`/directory tree by number of specified times(`count`) 


|Name | Description |
|-----|------|
|path ||
|count ||

**Returns**: 



---
## Type Helpers.ResourceHelper

 Provides methods for resource files 



---
#### Method Helpers.ResourceHelper.GetResourceLookup\<T\>(System.Type,System.String)

 Returns resource value out from given resource type by name 


|Name | Description |
|-----|------|
|T ||

|Name | Description |
|-----|------|
|resourceType ||
|resourceName ||

**Returns**: 



---
## Type Logging.Logger

 Provides methods for logging into console and text file with additional informations 



---
#### Property Logging.Logger.LogFile

 Path to a log file 



---
#### Method Logging.Logger.Error(System.Exception,System.String,System.String,System.Int32)

 Writes Error into console and file [Logging.Logger.LogFile]() with additional information about caller method, class and line 


|Name | Description |
|-----|------|
|ex ||
|callerName ||
|callerFilePath ||
|callerLine ||


---
#### Method Logging.Logger.Info(System.String,System.String,System.String,System.Int32)

 Writes Info into console and file [Logging.Logger.LogFile]() with additional information about caller method, class and line 


|Name | Description |
|-----|------|
|text ||
|callerName ||
|callerFilePath ||
|callerLine ||


---
#### Method Logging.Logger.Info(System.String,System.ConsoleColor,System.String,System.String,System.Int32)

 Writes Info into console and file [Logging.Logger.LogFile]()


|Name | Description |
|-----|------|
|text ||
|color ||
|callerName ||
|callerFilePath ||
|callerLine ||


---
#### Method Logging.Logger.Info(System.Object,System.String,System.String,System.Int32)

 Writes Info into console and file [Logging.Logger.LogFile]() with additional information about caller method, class and line 


|Name | Description |
|-----|------|
|text ||
|callerName ||
|callerFilePath ||
|callerLine ||


---
#### Method Logging.Logger.Warning(System.String,System.String,System.String,System.Int32)

 Writes Warning into console and file [Logging.Logger.LogFile]() with additional information about caller method, class and line 


|Name | Description |
|-----|------|
|text ||
|callerName ||
|callerFilePath ||
|callerLine ||


---
## Type Logging.ThreadSafeLogger

 Thread safe logger 



---
#### Property Logging.ThreadSafeLogger.LogFilePath

 Gets logger file path 



---
#### Property Logging.ThreadSafeLogger.Instance

 Returns instance of logger 



---
#### Method Logging.ThreadSafeLogger.SetLogFile(System.String)

 Sets log file location Note: Default location is application base directory 


|Name | Description |
|-----|------|
|pathToFile ||


---
#### Method Logging.ThreadSafeLogger.AddMessage(System.String)

 Adds message to queue 


|Name | Description |
|-----|------|
|message ||


---
#### Method Logging.ThreadSafeLogger.DispatchMesages

 Log all messages in queue 



---


