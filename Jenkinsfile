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
    	
    	def version = manifest.version.toString() 
    	def platformVersion = manifest.platformVersion.toString()
    	def title = manifest.title.toString()
    	def description = manifest.description.toString()
    	def projectUrl = manifest.projectUrl.toString()
    	def packageUrl = manifest.packageUrl.toString()
    	def iconUrl = manifest.iconUrl.toString()
    	
    	manifest = null
    	updateModule(
    		id, 
    		version, 
    		platformVersion,
    		title,
    		description,
    		projectUrl,
    		packageUrl,
    		iconUrl)
    		
    		

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

publishRelease()

//@NonCPS
def updateModule(def id, def version, def platformVersion, def title, def description, def projectUrl, def packageUrl, def iconUrl)
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
            
            println(builder.toPrettyString())
        }
}

def publishRelease()
{
	def userInput = input(id: 'userInput', message: 'Create release?') 
	node {
	echo "Compressing artifacts into one file"
	dir('deploy')
	{
		deleteDir()
	}
	
	zip dir: '', glob: '', zipFile: 'deploy\\artifacts.zip'
	

	//bat "${env.Utils}\\github-release info -u VirtoCommerce -r vc-module-jenkinssample"
	bat "${env.Utils}\\github-release release --user VirtoCommerce --repo vc-module-jenkinssample --tag v1.0 --name v1.0"
	bat "${env.Utils}\\github-release upload --user VirtoCommerce --repo vc-module-jenkinssample --tag v1.0 --name v1.0 --file \"deploy\\artifacts.zip\""

	/*
	zip -r artifacts.zip artifacts_folder
	
	echo "Exporting token and enterprise api to enable github-release tool"
	export GITHUB_TOKEN=$$$$$$$$$$$$
	export GITHUB_API=https://git.{your domain}.com/api/v3 # needed only for enterprise
	
	echo "Deleting release from github before creating new one"
	/path_to_bin/./github-release delete --user ${GITHUB_ORGANIZATION} --repo ${GITHUB_REPO} --tag ${VERSION_NAME}
	
	echo "Creating a new release in github"
	/path_to_bin/./github-release release --user ${GITHUB_ORGANIZATION} --repo ${GITHUB_REPO} --tag ${VERSION_NAME} --name "${VERSION_NAME}"
	
	echo "Uploading the artifacts into github"
	/path_to_bin/./github-release upload --user ${GITHUB_ORGANIZATION} --repo ${GITHUB_REPO} --tag ${VERSION_NAME} --name "${PROJECT_NAME}-${VERSION_NAME}.zip" --file artifacts.zip
	*/
	}
}
