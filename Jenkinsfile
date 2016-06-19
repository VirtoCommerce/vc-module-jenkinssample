#!groovy
import groovy.json.*
import groovy.util.*

node
{
	checkout scm
	def manifestFile = readFile file: 'module.manifest', encoding: 'utf-8'
	def manifest = new XmlSlurper().parseText(manifestFile)

	echo manifestFile
    	echo "Platform: $manifest.module.platformVersion"

/*
	//def moduleNode = json.find { it.id == 'VirtoCommerce.Store'}
	for (rec in json) {
    	if ( rec.id == 'VirtoCommerce.Store') {
        	println(rec.description)
            break
		}
	}
*/
}
