#!groovy
import groovy.json.*
import groovy.util.*

def REPO_ORG = "VirtoCommerce"
def REPO_NAME = "vc-module-jenkinssample"
node
{
	processManifests()

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


def processManifests()
{
	checkout scm
	
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
    	
    	def manifestDirectory = manifestPath.substring(0, manifestPath.length() - 16)
    	echo "publishing using $manifestDirectory dir"
    	publishRelease(manifestDirectory, version)
}

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
            
            println(builder.toString())
        }
}

def publishRelease(def manifestDirectory, def version)
{
	// check for publish commit & master branch
	bat "\"${tool 'Git'}\" log -1 --pretty=%%B > LAST_COMMIT_MESSAGE"
	git_last_commit=readFile('LAST_COMMIT_MESSAGE')
	
	if (env.BRANCH_NAME == 'master' && git_last_commit == 'publish')
	{
		def tempFolder = pwd(tmp: true)
		def wsFolder = pwd()
		def tempDir = "$tempFolder\\vc-module"
    		def modulesDir = "$tempDir\\_PublishedWebsites"
    		def packagesDir = "$wsFolder\\artifacts"
    		
    		dir(packagesDir)
		{
			deleteDir()
		}
    
    		buildSolutions()
		bat "\"${tool 'MSBuild 12.0'}\" \"$manifestDirectory\\VirtoCommerce.CoreModule.Web.csproj\" /nologo /verbosity:m /t:PackModule /p:Configuration=Release /p:Platform=\"Any CPU\" /p:DebugType=none /p:AllowedReferenceRelatedFileExtensions=: \"/p:OutputPath=$tempDir\" \"/p:VCModulesOutputDir=$modulesDir\" \"/p:VCModulesZipDir=$packagesDir\""

    		dir(packagesDir)
		{
			def artifacts = findFiles(glob: '*.zip')
			if(artifacts.size() > 0)
			{
				for(int i = 0; i < artifacts.size(); i++)
				{
					def artifact = artifacts[i]
					bat "${env.Utils}\\github-release release --user $REPO_ORG --repo $REPO_NAME --tag v${version}"
					bat "${env.Utils}\\github-release upload --user $REPO_ORG --repo $REPO_NAME --tag v${version} --name \"${artifact}\" --file \"${artifact}\""
				}
			}
		}

		//bat "${env.Utils}\\github-release info -u VirtoCommerce -r vc-module-jenkinssample"
	}
}

def buildSolutions()
{
	def solutions = findFiles(glob: '*.sln')

	if(solutions.size() > 0)
	{
		stage 'Build'
			for(int i = 0; i < solutions.size(); i++)
			{
				def solution = solutions[i]
				bat "Nuget restore ${solution.name}"
				bat "\"${tool 'MSBuild 12.0'}\" \"${solution.name}\" /p:Configuration=Debug /p:Platform=\"Any CPU\""
			}
	}
}
