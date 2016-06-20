#!groovy
import groovy.json.*
import groovy.util.*

node
{
	checkout scm
	
	def manifestFile = readFile file: 'module.manifest', encoding: 'utf-8'
	def manifest = new XmlSlurper().parseText(manifestFile)
	manifestFile = null

	//echo manifestFile
    	echo "Upading module ${manifest.id}"
    	def id = manifest.id.toString()
    	
    	updateModule(
    		id: manifest.id.toString(), 
    		version: manifest.version.toString(), 
    		platfromVersion: manifest.platformVersion.toString(),
    		title: manifest.title.toString(),
    		description: manifest.description.toString(),
    		projectUrl: manifest.projectUrl.toString(),
    		packageUrl: manifest.packageUrl.toString(),
    		iconUrl: manifest.iconUrl.toString())
    		
    	manifest = null

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

//@NonCPS
def updateModule(def id, def version, def platfromVersion, def title, def description, def projectUrl, def packageUrl, def iconUrl)
{
	// MODULES
        dir('modules') {
            checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], submoduleCfg: [], userRemoteConfigs: [[credentialsId: 'sasha-jenkins', url: 'git@github.com:VirtoCommerce/vc-modules.git']]])

            def inputFile = readFile file: 'modules.json', encoding: 'utf-8'
            def parser = new JsonSlurper()
            def json = parser.parseText(inputFile)
            def builder = new JsonBuilder(json)
            
            for (rec in json) {
               if ( rec.id == id) {
               	    rec.description = "test"
		break
               }
            }
            
            println(builder.toPrettyString())
        }
}
