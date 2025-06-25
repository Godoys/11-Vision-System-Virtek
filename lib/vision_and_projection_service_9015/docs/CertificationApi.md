# VisionAndProjectionService.Swagger.Api.CertificationApi

All URIs are relative to *http://localhost:9015*

 Method                                                                                                                       | HTTP request                                                           | Description                                                                     
------------------------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------|---------------------------------------------------------------------------------
 [**CoreLaserServiceCertifyAlignment**](CertificationApi.md#corelaserservicecertifyalignment)                                 | **POST** /CertifyAlignment                                             | Performs a Certification using the specified projector and the open Work Order. 
 [**CoreLaserServiceGetCertificationReportFile**](CertificationApi.md#corelaserservicegetcertificationreportfile)             | **GET** /WorkOrders/{workOrder}/CertificationReports/{reportId}/{file} | Serves a specific report/data file from a certification report                  
 [**CoreLaserServiceGetCertificationReportIndex**](CertificationApi.md#corelaserservicegetcertificationreportindex)           | **GET** /WorkOrders/{workOrder}/CertificationReports                   | Serves an index of certification reports for a given work order.                
 [**CoreLaserServiceHandleUpdateCertificationRequest**](CertificationApi.md#corelaserservicehandleupdatecertificationrequest) | **POST** /UpdateCertificationRequest                                   | See \&quot;Manual Calibration\&quot; in Integrators Guide                       

<a name="corelaserservicecertifyalignment"></a>

# **CoreLaserServiceCertifyAlignment**

> ResultDtoCertifyAlignmentResultDto CoreLaserServiceCertifyAlignment (CertifyAlignmentDto certifyDto)

Performs a Certification using the specified projector and the open Work Order.

Same as clicking \"Certify Alignment\" in the alignment controls, Iris Client &gt; Projector Panel &gt; Targets Tab;
Work Order must be a Certification Work Order. See \"Certification\" in Iris System Administrator Guide. Report produced
can be obtained using `/WorkOrders/{workOrder}/CertificationReports` and
`/WorkOrders/{workOrder}/CertificationReports/{reportId}/{file}`    * **AlignBeforeCertify** - Whether to align before
certifying, true or false, however true must be used to do a proper certification * **DisplayUnits** - Units used in the
report. Use 'Metres', 'Centimetres', 'Millimetres', 'Yards', 'Feet', 'Inches', or 'BuildersUnits' * *
*ReportSoftwareVersion** - String that will be shown in the “Build” field on the report, you are responsible for
supplying the version * **LocalizeTagResources** - Set as [“Certification”, “Alignment”, “Disabled”] (only legal
value)  * **CertificationReportTargets** - Target names of targets used in report  <example>
CertifyAlignmentDto { ClientInfo (ClientInfoDto, required), ProjectorSerial (string, required), AlignBeforeCertify (
boolean, required), DisplayUnits (Units, optional), ReportSoftwareVersion (string, optional), LocalizeTagResources (
Array[string], optional), CertificationReportTargets (Array[string], optional)              } ClientInfoDto { ClientId (
string, required), OriginatingClientGuid (string, optional), Type (string,
optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCertifyAlignmentExample
    {
        public void main()
        {
            var apiInstance = new CertificationApi();
            var certifyDto = new CertifyAlignmentDto(); // CertifyAlignmentDto | Service call parameters.

            try
            {
                // Performs a Certification using the specified projector and the open Work Order.
                ResultDtoCertifyAlignmentResultDto result = apiInstance.CoreLaserServiceCertifyAlignment(certifyDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificationApi.CoreLaserServiceCertifyAlignment: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                              | Description              | Notes 
----------------|---------------------------------------------------|--------------------------|-------
 **certifyDto** | [**CertifyAlignmentDto**](CertifyAlignmentDto.md) | Service call parameters. |

### Return type

[**ResultDtoCertifyAlignmentResultDto**](ResultDtoCertifyAlignmentResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetcertificationreportfile"></a>

# **CoreLaserServiceGetCertificationReportFile**

> Object CoreLaserServiceGetCertificationReportFile (string workOrder, string reportId, string file)

Serves a specific report/data file from a certification report

The method `/GetCertificationReportIndex` returns a list of available Certification Reports for the specified Work
Order. For each report, a csv format and an HTML form is available. This method returns the actual report file specified
by Report ID   (the first subfolder in the URLs returned above) and the report file name, all of which are named
according to:  `CERT_{projector serial}_{date}_{time}`

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetCertificationReportFileExample
    {
        public void main()
        {
            var apiInstance = new CertificationApi();
            var workOrder = workOrder_example;  // string | Work order identifier, corresponding to the work order folder name.
            var reportId = reportId_example;  // string | Certification report identifier, e.g. CERT_16040006_Nov062019_015602PM
            var file = file_example;  // string | File to serve. Must be contained directly in the report folder.

            try
            {
                // Serves a specific report/data file from a certification report
                Object result = apiInstance.CoreLaserServiceGetCertificationReportFile(workOrder, reportId, file);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificationApi.CoreLaserServiceGetCertificationReportFile: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name          | Type       | Description                                                            | Notes 
---------------|------------|------------------------------------------------------------------------|-------
 **workOrder** | **string** | Work order identifier, corresponding to the work order folder name.    |
 **reportId**  | **string** | Certification report identifier, e.g. CERT_16040006_Nov062019_015602PM |
 **file**      | **string** | File to serve. Must be contained directly in the report folder.        |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetcertificationreportindex"></a>

# **CoreLaserServiceGetCertificationReportIndex**

> Object CoreLaserServiceGetCertificationReportIndex (string workOrder)

Serves an index of certification reports for a given work order.

Returns the index.html list of all certification reports for the specified work order. Same as the one hosted by the
Vision and Projection Server at this URL:     <example>                   http://(Virtek Server hostname):
9015/WorkOrders/(Work Order name)/CertificationReports/                 </example>    ..where 9015 is the default port
for Vision and Alignment Service. See `/GetCertificationReportFile` for an example returned by this call.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetCertificationReportIndexExample
    {
        public void main()
        {
            var apiInstance = new CertificationApi();
            var workOrder = workOrder_example;  // string | Work order identifier, corresponding to the work order folder name.

            try
            {
                // Serves an index of certification reports for a given work order.
                Object result = apiInstance.CoreLaserServiceGetCertificationReportIndex(workOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificationApi.CoreLaserServiceGetCertificationReportIndex: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name          | Type       | Description                                                         | Notes 
---------------|------------|---------------------------------------------------------------------|-------
 **workOrder** | **string** | Work order identifier, corresponding to the work order folder name. |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicehandleupdatecertificationrequest"></a>

# **CoreLaserServiceHandleUpdateCertificationRequest**

> ResultDtoListTupleStringStringString CoreLaserServiceHandleUpdateCertificationRequest (TargetListInfoDto targetInfo)

See \"Manual Calibration\" in Integrators Guide

<example>              TargetListInfoDto {                  ClientInfo  (ClientInfoDto, required),                  TargetNameList (Array[string], required),                  Certification (boolean, required)              }              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceHandleUpdateCertificationRequestExample
    {
        public void main()
        {
            var apiInstance = new CertificationApi();
            var targetInfo = new TargetListInfoDto(); // TargetListInfoDto | the target Information

            try
            {
                // See \"Manual Calibration\" in Integrators Guide
                ResultDtoListTupleStringStringString result = apiInstance.CoreLaserServiceHandleUpdateCertificationRequest(targetInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CertificationApi.CoreLaserServiceHandleUpdateCertificationRequest: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                          | Description            | Notes 
----------------|-----------------------------------------------|------------------------|-------
 **targetInfo** | [**TargetListInfoDto**](TargetListInfoDto.md) | the target Information |

### Return type

[**ResultDtoListTupleStringStringString**](ResultDtoListTupleStringStringString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

