﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileSdkGen.CodeGen.ObjectiveC {
    using System;


    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TemplateResources {

        private static global::System.Resources.ResourceManager resourceMan;

        private static global::System.Globalization.CultureInfo resourceCulture;

        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TemplateResources() {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MobileSdkGen.CodeGen.ObjectiveC.TemplateResources", typeof(TemplateResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to @property (nonatomic, strong) {!ATTRIBUTE_TYPE} *{!ATTRIBUTE_NAME};.
        /// </summary>
        internal static string H_Attribute_Begin {
            get {
                return ResourceManager.GetString("H_Attribute_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to
        ///@interface {!ENTITY_NAME} : Entity
        ///
        ///+ (NSString *)entityLogicalName;
        ///+ (NSNumber *)entityTypeCode;
        ///.
        /// </summary>
        internal static string H_Entity_Begin {
            get {
                return ResourceManager.GetString("H_Entity_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to
        ///@end
        ///.
        /// </summary>
        internal static string H_Entity_End {
            get {
                return ResourceManager.GetString("H_Entity_End", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to //
        /////  {!FILE_NAME}.h
        /////  Microsoft Xrm Mobile SDK
        /////
        /////  Created by Microsoft Corporation
        /////  Copyright (c) 2015 Microsoft. All rights reserved.
        /////
        ///
        ///#import &quot;Entity.h&quot;
        ///.
        /// </summary>
        internal static string H_File_Begin {
            get {
                return ResourceManager.GetString("H_File_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 	{!OPTION_NAME} = {!OPTION_VALUE}.
        /// </summary>
        internal static string H_Option_Begin {
            get {
                return ResourceManager.GetString("H_Option_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to
        ///typedef enum {.
        /// </summary>
        internal static string H_OptionSet_Begin {
            get {
                return ResourceManager.GetString("H_OptionSet_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to } {!OPTIONSET_NAME};
        ///.
        /// </summary>
        internal static string H_OptionSet_End {
            get {
                return ResourceManager.GetString("H_OptionSet_End", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 	@AttributeLogicalNameAttribute(accessor = Accessors.GET, value = &quot;{!ATTRIBUTE_LOGICALNAME}&quot;)
        ///	public {!ATTRIBUTE_TYPE} get{!ATTRIBUTE_NAME_UPPER}() {
        ///		return this.GetAttributeValue(&quot;{!ATTRIBUTE_LOGICALNAME}&quot;);
        ///	}
        ///
        ///	@AttributeLogicalNameAttribute(accessor = Accessors.SET, value = &quot;{!ATTRIBUTE_LOGICALNAME}&quot;)
        ///	public void set{!ATTRIBUTE_NAME_UPPER}({!ATTRIBUTE_TYPE} value) {
        ///		this.SetAttributeValue(&quot;{!ATTRIBUTE_LOGICALNAME}&quot;, value);
        ///	}
        ///.
        /// </summary>
        internal static string Java_Attribute_Begin {
            get {
                return ResourceManager.GetString("Java_Attribute_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to @EntityLogicalNameAttribute(&quot;{!ENTITY_LOGICALNAME}&quot;)
        ///public class {!ENTITY_NAME} extends Entity {
        ///
        ///	public static final String EntityLogicalName = &quot;{!ENTITY_LOGICALNAME}&quot;;
        ///	public static final int EntityTypeCode = {!ENTITY_TYPECODE};
        ///
        ///	public {!ENTITY_NAME}() {
        ///		super(&quot;{!ENTITY_LOGICALNAME}&quot;);
        ///	}
        ///
        ///	@AttributeLogicalNameAttribute(accessor = Accessors.GET, value = &quot;{!ENTITY_PRIMARYID_LOGICALNAME}&quot;)
        ///	public UUID get{!ENTITY_PRIMARYID_NAME}() {
        ///		return this.GetAttributeValue(&quot;{!ENTITY_PRIMARYID_ [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Java_Entity_Begin {
            get {
                return ResourceManager.GetString("Java_Entity_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to }
        ///.
        /// </summary>
        internal static string Java_Entity_End {
            get {
                return ResourceManager.GetString("Java_Entity_End", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to //
        /////  {!FILE_NAME}.java
        /////  Microsoft Xrm Mobile SDK
        /////
        /////  Copyright (c) 2015 Microsoft. All rights reserved.
        /////
        ///
        ///import java.math.BigDecimal;
        ///import java.math.BigInteger;
        ///import java.util.Date;
        ///import java.util.UUID;
        ///import java.util.ArrayList;
        ///import com.microsoft.xrm.sdk.*;
        ///
        ///.
        /// </summary>
        internal static string Java_File_Begin {
            get {
                return ResourceManager.GetString("Java_File_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 	{!OPTION_NAME}({!OPTION_VALUE}){!OPTION_SEPARATOR}.
        /// </summary>
        internal static string Java_Option_Begin {
            get {
                return ResourceManager.GetString("Java_Option_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 			case {!OPTION_VALUE}:
        ///				return {!OPTION_NAME};.
        /// </summary>
        internal static string Java_Option_ToObjectCase {
            get {
                return ResourceManager.GetString("Java_Option_ToObjectCase", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to public enum {!OPTIONSET_NAME} {.
        /// </summary>
        internal static string Java_OptionSet_Begin {
            get {
                return ResourceManager.GetString("Java_OptionSet_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to 	private int mValue;
        ///
        ///	{!OPTIONSET_NAME}(int value) {
        ///		mValue = value;
        ///	}
        ///
        ///	public int getValue() {
        ///		return mValue;
        ///	}
        ///
        ///	public static {!OPTIONSET_NAME} toObject(int value) {
        ///		switch(value) {
        ///{!OPTIONSET_TO_OBJECT_CASES}			default:
        ///				return null;
        ///		}
        ///	}
        ///}
        ///.
        /// </summary>
        internal static string Java_OptionSet_End {
            get {
                return ResourceManager.GetString("Java_OptionSet_End", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to - ({!ATTRIBUTE_TYPE} *){!ATTRIBUTE_NAME} {
        ///	return ({!ATTRIBUTE_TYPE} *)self.attributes[@&quot;{!ATTRIBUTE_LOGICALNAME}&quot;];
        ///}
        ///
        ///- (void)set{!ATTRIBUTE_NAME_UPPER}:({!ATTRIBUTE_TYPE} *){!ATTRIBUTE_NAME} {
        ///	self.attributes[@&quot;{!ATTRIBUTE_LOGICALNAME}&quot;] = {!ATTRIBUTE_NAME};
        ///}
        ///.
        /// </summary>
        internal static string M_Attribute_Begin {
            get {
                return ResourceManager.GetString("M_Attribute_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to
        ///@implementation {!ENTITY_NAME}
        ///
        ///+ (NSString *)entityLogicalName
        ///{
        ///	return @&quot;{!ENTITY_LOGICALNAME}&quot;;
        ///}
        ///
        ///+ (NSNumber *)entityTypeCode
        ///{
        ///	return [NSNumber numberWithInt:{!ENTITY_TYPECODE}];
        ///}
        ///
        ///- (NSUUID *)id
        ///{
        ///	return (NSUUID *)self.attributes[@&quot;{!ENTITY_PRIMARYID}&quot;];
        ///}
        ///
        ///- (void)setId:(NSUUID *)id
        ///{
        ///	self.attributes[@&quot;{!ENTITY_PRIMARYID}&quot;] = id;
        ///}
        ///.
        /// </summary>
        internal static string M_Entity_Begin {
            get {
                return ResourceManager.GetString("M_Entity_Begin", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to - (id)init
        ///{
        ///	return [super initWithLogicalName:@&quot;{!ENTITY_LOGICALNAME}&quot;];
        ///}
        ///
        ///@end
        ///.
        /// </summary>
        internal static string M_Entity_End {
            get {
                return ResourceManager.GetString("M_Entity_End", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to //
        /////  {!FILE_NAME}.m
        /////  Microsoft Xrm Mobile SDK
        /////
        /////  Created by Microsoft Corporation
        /////  Copyright (c) 2015 Microsoft. All rights reserved.
        /////
        ///
        ///#import &quot;{!FILE_NAME}.h&quot;
        ///.
        /// </summary>
        internal static string M_File_Begin {
            get {
                return ResourceManager.GetString("M_File_Begin", resourceCulture);
            }
        }
    }
}
