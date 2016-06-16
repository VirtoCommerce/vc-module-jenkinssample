node 
{
	stage 'Checkout'
        checkout([
            $class: 'GitSCM', 
            branches: [[name: '*/master']], 
            extensions: [[
			    $class: 'PathRestriction', 
			    excludedRegions: 'CommonAssemblyInfo\\.cs', 
			    includedRegions: ''
		    ]], 
            userRemoteConfigs: [[
                url: 'git@github.com:VirtoCommerce/vc-module-jenkinssample.git']]])
                
        properties([[$class: 'NoTriggerOrganizationFolderProperty']])
}
