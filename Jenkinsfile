#!groovy
import groovy.json.*
import groovy.util.*

node
{
	checkout scm
	def manifestFile = readFile file: 'module.manifest', encoding: 'utf-8'
	def manifest = new XmlSlurper().parseText(manifestFile)

	echo manifestFile
	def title = manifest.title.toString()
	def title2 = manifest.module.toString()
    	echo "Platform: ${title} - ${title2}"
    	
    	var module = new Module(
    		id: manifest.id
    		version: manifest.version
    		platformVersion: manifest.platformVersion
    		title: manifest.title
    		description: manifest.description
    	)
    	jsonBuilder(module)
	println("Using list of objects")
	println(jsonBuilder.toPrettyString())

/*
	//def moduleNode = json.find { it.id == 'VirtoCommerce.Store'}
	for (rec in json) {
    	if ( rec.id == 'VirtoCommerce.Store') {
        	println(rec.description)
            break
		}
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

class Module {
    def id
    def version
    def platformVersion
    def title
    def description
    def groups
    def authors
    def owners
    def projectUrl
    def iconUrl
    def packageUrl
}
