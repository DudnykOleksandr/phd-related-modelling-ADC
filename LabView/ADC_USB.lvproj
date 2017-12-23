<?xml version='1.0' encoding='UTF-8'?>
<Project Type="Project" LVVersion="11008008">
	<Item Name="My Computer" Type="My Computer">
		<Property Name="server.app.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.control.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="server.tcp.enabled" Type="Bool">false</Property>
		<Property Name="server.tcp.port" Type="Int">0</Property>
		<Property Name="server.tcp.serviceName" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.tcp.serviceName.default" Type="Str">My Computer/VI Server</Property>
		<Property Name="server.vi.callsEnabled" Type="Bool">true</Property>
		<Property Name="server.vi.propertiesEnabled" Type="Bool">true</Property>
		<Property Name="specify.custom.address" Type="Bool">false</Property>
		<Item Name="ADC_USB.vi" Type="VI" URL="../ADC_USB.vi"/>
		<Item Name="Dependencies" Type="Dependencies">
			<Item Name="vi.lib" Type="Folder">
				<Item Name="Dynamic To Waveform Array.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/transition.llb/Dynamic To Waveform Array.vi"/>
				<Item Name="ex_CorrectErrorChain.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/ex_CorrectErrorChain.vi"/>
				<Item Name="Ex_Extract Single Tone.vi" Type="VI" URL="/&lt;vilib&gt;/express/express analysis/ToneBlock.llb/Ex_Extract Single Tone.vi"/>
				<Item Name="ex_Modify Signal Name.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/ex_Modify Signal Name.vi"/>
				<Item Name="ex_Modify Signals Names.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/ex_Modify Signals Names.vi"/>
				<Item Name="Express Harmonic Distortion .vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/Express Harmonic Distortion .vi"/>
				<Item Name="Express SINAD Analyzer.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/Express SINAD Analyzer.vi"/>
				<Item Name="Move t0 to the end.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/transition.llb/Move t0 to the end.vi"/>
				<Item Name="NI_AALBase.lvlib" Type="Library" URL="/&lt;vilib&gt;/Analysis/NI_AALBase.lvlib"/>
				<Item Name="NI_AALPro.lvlib" Type="Library" URL="/&lt;vilib&gt;/Analysis/NI_AALPro.lvlib"/>
				<Item Name="NI_MABase.lvlib" Type="Library" URL="/&lt;vilib&gt;/measure/NI_MABase.lvlib"/>
				<Item Name="NI_MAPro.lvlib" Type="Library" URL="/&lt;vilib&gt;/measure/NI_MAPro.lvlib"/>
				<Item Name="subDistortionMeasurements.vi" Type="VI" URL="/&lt;vilib&gt;/express/express analysis/DistortionBlock.llb/subDistortionMeasurements.vi"/>
				<Item Name="Waveform Array To Dynamic.vi" Type="VI" URL="/&lt;vilib&gt;/express/express shared/transition.llb/Waveform Array To Dynamic.vi"/>
			</Item>
			<Item Name="FT_Close_Device.vi" Type="VI" URL="../FT_Close_Device.vi"/>
			<Item Name="FT_Get_Device_Description_By_Index.vi" Type="VI" URL="../FT_Get_Device_Description_By_Index.vi"/>
			<Item Name="FT_Get_Queue_Status.vi" Type="VI" URL="../FT_Get_Queue_Status.vi"/>
			<Item Name="FT_Open_Device_By_Description.vi" Type="VI" URL="../FT_Open_Device_By_Description.vi"/>
			<Item Name="FT_Purge.vi" Type="VI" URL="../FT_Purge.vi"/>
			<Item Name="FT_Read_Byte_Data.vi" Type="VI" URL="../FT_Read_Byte_Data.vi"/>
			<Item Name="FT_Reset_Device.vi" Type="VI" URL="../FT_Reset_Device.vi"/>
			<Item Name="ftd2xx.dll" Type="Document" URL="../../../../../../ftd2xx.dll"/>
			<Item Name="LabViewDllNet.dll" Type="Document" URL="../../LabViewDllNet/bin/Debug/LabViewDllNet.dll"/>
			<Item Name="lvanlys.dll" Type="Document" URL="/C/Program Files (x86)/National Instruments/LabVIEW 2011/resource/lvanlys.dll"/>
		</Item>
		<Item Name="Build Specifications" Type="Build">
			<Item Name="ADC_USB" Type="EXE">
				<Property Name="App_copyErrors" Type="Bool">true</Property>
				<Property Name="App_INI_aliasGUID" Type="Str">{33CC9B49-A47A-4100-AD69-97A38DD11226}</Property>
				<Property Name="App_INI_GUID" Type="Str">{5A9CC742-4461-4729-B7B8-18A957DB3448}</Property>
				<Property Name="Bld_buildCacheID" Type="Str">{695732E4-3992-4496-8ADA-CAC7D35AC034}</Property>
				<Property Name="Bld_buildSpecName" Type="Str">ADC_USB</Property>
				<Property Name="Bld_excludeLibraryItems" Type="Bool">true</Property>
				<Property Name="Bld_excludePolymorphicVIs" Type="Bool">true</Property>
				<Property Name="Bld_localDestDir" Type="Path">../builds/NI_AB_PROJECTNAME/ADC_USB</Property>
				<Property Name="Bld_localDestDirType" Type="Str">relativeToCommon</Property>
				<Property Name="Bld_modifyLibraryFile" Type="Bool">true</Property>
				<Property Name="Bld_previewCacheID" Type="Str">{1903B2FB-F1DC-46EC-8347-B239ED90B749}</Property>
				<Property Name="Destination[0].destName" Type="Str">Application.exe</Property>
				<Property Name="Destination[0].path" Type="Path">../builds/NI_AB_PROJECTNAME/ADC_USB/Application.exe</Property>
				<Property Name="Destination[0].preserveHierarchy" Type="Bool">true</Property>
				<Property Name="Destination[0].type" Type="Str">App</Property>
				<Property Name="Destination[1].destName" Type="Str">Support Directory</Property>
				<Property Name="Destination[1].path" Type="Path">../builds/NI_AB_PROJECTNAME/ADC_USB/data</Property>
				<Property Name="DestinationCount" Type="Int">2</Property>
				<Property Name="Source[0].itemID" Type="Str">{44578ABE-CC62-4B8C-A7EF-AFEBAC34342C}</Property>
				<Property Name="Source[0].type" Type="Str">Container</Property>
				<Property Name="Source[1].destinationIndex" Type="Int">0</Property>
				<Property Name="Source[1].itemID" Type="Ref">/My Computer/ADC_USB.vi</Property>
				<Property Name="Source[1].sourceInclusion" Type="Str">TopLevel</Property>
				<Property Name="Source[1].type" Type="Str">VI</Property>
				<Property Name="SourceCount" Type="Int">2</Property>
				<Property Name="TgtF_fileDescription" Type="Str">ADC_USB</Property>
				<Property Name="TgtF_fileVersion.major" Type="Int">1</Property>
				<Property Name="TgtF_internalName" Type="Str">ADC_USB</Property>
				<Property Name="TgtF_legalCopyright" Type="Str">Copyright © 2012 </Property>
				<Property Name="TgtF_productName" Type="Str">ADC_USB</Property>
				<Property Name="TgtF_targetfileGUID" Type="Str">{F43072AE-5A81-4922-9D1F-26EFDC72F60A}</Property>
				<Property Name="TgtF_targetfileName" Type="Str">Application.exe</Property>
			</Item>
		</Item>
	</Item>
</Project>
