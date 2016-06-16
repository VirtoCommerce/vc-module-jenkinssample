node 
{
	stage 'Checkout'
	
	checkout scm
    	checkout([$class: 'GitSCM', branches: [[name: '*/' + env.BRANCH_NAME]],
        	extensions: [[$class: 'CleanCheckout'],[$class: 'LocalBranch', localBranch: env.BRANCH_NAME]]])
        
	/*
        checkout([
            $class: 'GitSCM', 
            branches: [[name: 'master']], 
            extensions: [[
			    $class: 'PathRestriction', 
			    excludedRegions: 'CommonAssemblyInfo\\.cs', 
			    includedRegions: ''
		    ]], 
            userRemoteConfigs: [[
                url: 'git@github.com:VirtoCommerce/vc-module-jenkinssample.git']]])
         */
}
