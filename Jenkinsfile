#!groovy
import groovy.json.*
import groovy.util.*

node
{
	def manifest = new XmlSlurper().parse("module.manifest")

    	println(manifest.module.id)

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
