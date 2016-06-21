#!groovy
import groovy.json.*
import groovy.util.*

    
    node
    {
      		stage 'Checkout'
			checkout scm
		
			stage 'Publishing'
				processManifests()
		
 
    }

def processManifests()
{
	// find all manifests
	def manifests = findFiles(glob: '**\\module.manifest')
		
	if(manifests.size() > 0)
	{
		for(int i = 0; i < manifests.size(); i++)
		{
			def manifest = manifests[i]
			processManifest(manifest.path)
		}
	}
	else
	{
		echo "no module.manifest files found"
	}
}

def processManifest(def manifestPath)
{
	echo "reading $manifestPath"
	def manifestFile = readFile file: "$manifestPath", encoding: 'utf-8'
	def manifest = new XmlSlurper().parseText(manifestFile)
	manifestFile = null

	//echo manifestFile
    	echo "Upading module ${manifest.id}"
    	def id = manifest.id.toString()
    	
    	def version = manifest.version.toString() 
    	def platformVersion = manifest.platformVersion.toString()
    	def title = manifest.title.toString()
    	def description = manifest.description.toString()
    	def projectUrl = manifest.projectUrl.toString()
    	def packageUrl = manifest.packageUrl.toString()
    	def iconUrl = manifest.iconUrl.toString()
    	
    	// get dependencies
    	def dependencies = []
    	for(int i = 0; i < manifest.dependencies.size(); i++)
	{
		def dependency = manifest.dependencies[i]
		def dependencyObj = [id: dependency["id"], version: dependency["version"]]
		dependencies.add(dependencyObj)
	}
	
    	manifest = null
    	
    	def manifestDirectory = manifestPath.substring(0, manifestPath.length() - 16)
    	
    	updateModule(
    		id, 
    		version, 
    		platformVersion,
    		title,
    		description,
    		dependencies,
    		projectUrl,
    		packageUrl,
    		iconUrl)
}

def updateModule(def id, def version, def platformVersion, def title, def description, def dependencies, def projectUrl, def packageUrl, def iconUrl)
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
               	    rec.description = description
               	    rec.title = title
               	    rec.description = description
               	    rec.dependencies = dependencies
               	    if (projectUrl!=null && projectUrl.length()>0)
               	    {
               	    	rec.projectUrl = projectUrl
               	    }
               	    if (packageUrl!=null && packageUrl.length()>0)
               	    {
               	    	rec.packageUrl = packageUrl
               	    }
               	    if (iconUrl!=null && iconUrl.length()>0)
               	    {
               	    	rec.iconUrl = iconUrl
               	    }
		break
               }
            }
            
            println(builder.toString())
        }
}
