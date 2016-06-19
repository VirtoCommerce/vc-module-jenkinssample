#!groovy
import groovy.json.*

node
{
	def inputFile = readFile file: 'module.manifest', encoding: 'utf-8'
    def parser = new JsonSlurper()
    def json = parser.parseText(inputFile)
    def builder = new JsonBuilder(json)
    
    println(json.module.id)

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
