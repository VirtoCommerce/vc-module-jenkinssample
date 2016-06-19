#!groovy
import groovy.json.*
import groovy.util.*

node
{
	
	checkout scm
	def manifestFile = readFile file: 'module.manifest', encoding: 'utf-8'
	
	dir('modules') {
            	checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: 'sasha-jenkins', url: 'git@github.com:VirtoCommerce/vc-modules.git']]])
		def modulesFile = readFile file: 'modules.json', encoding: 'utf-8'
	}
	
	def manifest = new XmlSlurper().parseText(manifestFile)
	def modules = new XmlSlurper().parseText(modulesFile)
	
	def builder = new JsonBuilder(modules)
            
        for (rec in json) {
               if ( rec.id == manifest.id) {
               	    echo "found record, updating ${rec.id}"
               	    rec.description = "test"
		break
               }
        }
            
        println(builder.toPrettyString())
	
	/*
	//echo manifestFile
    	echo "Upading module ${manifest.id}"
    		// MODULES
    		
    	*/
    		/*
        dir('modules') {
            echo "checkout"
            checkout([$class: 'GitSCM', branches: [[name: 'master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: 'sasha-jenkins', url: 'git@github.com:VirtoCommerce/vc-modules.git']]])
		
		echo "reading file"
		

            def inputFile = readFile file: 'modules.json', encoding: 'utf-8'
             echo inputFile
            def parser = new JsonSlurper()
            def json = parser.parseText(inputFile)
            echo json
            def builder = new JsonBuilder(json)
            
            for (rec in json) {
               if ( rec.id == manifest.id) {
               	    echo "found record, updating ${rec.id}"
               	    rec.description = "test"
		break
               }
            }
            
            println(builder.toPrettyString())
        }
                    */

/*

        "id": "VirtoCommerce.Core",
        "version": "2.12.0",
        "platformVersion": "2.11.0",
        "title": "Commerce core module",
        "description": "Common e-commerce domain functionality",
        "groups": [ "commerce" ],
        "authors": [ "Virto Commerce" ],
        "owners": [ "Virto Commerce" ],
        "projectUrl": "https://github.com/VirtoCommerce/vc-module-core",
        "iconUrl": "https://raw.githubusercontent.com/VirtoCommerce/vc-module-core/master/VirtoCommerce.CoreModule.Web/Content/logoVC.png",
        "packageUrl": "https://github.com/VirtoCommerce/vc-module-core/releases/download/v2.12/VirtoCommerce.Core_2.12.0.zip"

*/
}

def updateModule(def manifest)
{

}
