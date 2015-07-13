## Dynamics CRM Mobile SDK Early-bound Types Generator

The *MobileSdkGen* tool reads entity and option-set metadata from your Dynamics CRM organization, including custom and customized entities, and then creates output files containing early-bound type classes for each CRM entity and option set that was read. You add the output files to your mobile app project to enable access to these CRM specific classes. This MobileSdkGen tool can create both Java (Android) and Objective-C (iOS) output files. Since this tool is written as a .NET application, you will need a development computer running .NET Framework 4.0 or later to build the tool from the provided source code.

This tool is similar to the *CrmSvcUtil* tool provided in the .NET version of the CRM SDK. For more information on the CrmSvcUtil tool and generating early-bound types, refer to the topic [Create early bound entity classes with the code generation tool (CrmSvcUtil.exe)](https://msdn.microsoft.com/en-us/library/gg327844.aspx).

### Building the tool

When building the tool from the provided source code, several [NuGet](http://nuget.org) packages will be downloaded as part of the build process. You will need Internet access on your development computer for this to happen or the build will fail.

To build the tool, follow these steps.
1. Open the provided solution file, named MobileSdkGen/MobileSdkGen.sln, in Visual Studio.
2. Choose **Build** > **Build Solution**.

### Running the tool

After building the tool, the MobileSdkGen.exe executable will reside in your bin\Debug or bin\Release folder. Running the tool without any command line arguments displays usage information.

Below is the command syntax.

```
MobileSdkGen.exe -c "Url=[org root url]; Username=[username]; Password=[password]" -o [output file/folder name] -j -i -m [path to XML model file]```


For example:
```MobileSdkGen -c "Url=https://myorg.crm.dynamics.com/; Username=un; Password=pw" -o MyModel -j```

#### Supported Command Arguments

Below are the supported command line arguments.
```
   Argument   | Description
-------------------------------------------------------------------------------------------------
        -c      Name: Connection String
                Description: The connection string to be used to connect to the CRM Organization.
                Boolean: No
                Required: Yes

        -o      Name: Output File
                Description: The path or name for the code file(s) to be generated. Should not
                             include a file suffix.
                Boolean: No
                Required: Yes

        -m      Name: Model File
                Description: The path or file name for the XML model file used to select entities
                             to generate.
                Boolean: No
                Required: No

        -j      Name: Generate Java
                Description: Generate the code in Java.
                Boolean: Yes
                Required: No

        -i      Name: Generate Objective C
                Description: Generate the code in Objective C.
                Boolean: Yes
                Required: No
```

The `-o` command argument is the name of the file or folder you want the output to go to. If you are generating Objective-C, then all classes are written into one file with the specified name. If you are generating Java, then the output folder with the specified name will contain one Java file for each option-set and entity read.

#### Restricting Output to an Entity Set

The `-m` argument is used to specify an XML model file that identifies the entities and attributes that you do want in the generated output.

The following XML code examples shows how to generate output for the complete Account entity, and only the 'contactid' and 'fullname' attributes of the Contact entity. All global option-sets are also included in the output.

``` xml
<?xml version="1.0" encoding="utf-8" ?>
<Model xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="Entities.xsd"
    IncludeAllEntities="false" IncludeAllGlobalOptionSets="true">
  <Entities>
    <Entity Name="account" />
    <Entity Name="contact" >
      <Attributes>
        <Attribute Name="contactid"/>
        <Attribute Name="fullname"/>
      </Attributes>
    </Entity>
  </Entities>
</Model>
```

The schema for the XML model file is shown below. This schema is included in an XSD file named ModelFileSchema.xsd that is provided in this SDK.

``` xml
<?xml version="1.0" encoding="utf-8"?>
<xs:schema xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" attributeFormDefault="unqualified" elementFormDefault="qualified" xmlns:xs="http://www.w3.org/2001/XMLSchema">
  <xs:element name="Model">
    <xs:complexType>
      <xs:sequence>
        <xs:element name="Entities">
          <xs:complexType>
            <xs:sequence>
              <xs:element maxOccurs="unbounded" name="Entity">
                <xs:complexType>
                  <xs:sequence minOccurs="0">
                    <xs:element name="Attributes">
                      <xs:complexType>
                        <xs:sequence>
                          <xs:element name="Attribute">
                            <xs:complexType>
                              <xs:attribute name="Name" type="xs:string" use="required" />
                            </xs:complexType>
                          </xs:element>
                        </xs:sequence>
                      </xs:complexType>
                    </xs:element>
                  </xs:sequence>
                  <xs:attribute name="Name" type="xs:string" use="required" />
                </xs:complexType>
              </xs:element>
            </xs:sequence>
          </xs:complexType>
        </xs:element>
      </xs:sequence>
      <xs:attribute name="IncludeAllEntities" type="xs:boolean" use="required" />
      <xs:attribute name="IncludeAllGlobalOptionSets" type="xs:boolean" use="required" />
    </xs:complexType>
  </xs:element>
</xs:schema>
```
