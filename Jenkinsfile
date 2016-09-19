node ('windows') {
    timestamps{
        stage('Checkout') {
            git credentialsId: 'joost-github', url: 'https://github.com/joostvdg/c-sharp-example.git'
        }

        def sonarHome = tool name: 'SonarQubeScannerMS', type: 'hudson.plugins.sonar.MsBuildSQRunnerInstallation'
        stage('Sonar Start'){
            // start
            bat "\"${sonarHome}\\MSBuild.SonarQube.Runner.exe\" begin /key:ProjectKey /name:ProjectName /version:1.0"
        }

        stage('Build'){
            def msbuildHome = tool name: 'default', type: 'hudson.plugins.msbuild.MsBuildInstallation'
            echo "msbuildHome=${msbuildHome}"
            bat "\"${msbuildHome}\\msbuild\" /t:Rebuild"
        }

        stage('Sonar Finish'){
            // finish
            // step([$class: 'MsBuildSQRunnerEnd'])
            bat "\"${sonarHome}\\MSBuild.SonarQube.Runner.exe\" end"
        }

        stage('Publish NuGet Package') {
            withCredentials([[$class: 'FileBinding', credentialsId: 'nuget', variable: 'nuget']]) {
                withCredentials([[$class: 'StringBinding', credentialsId: 'nuget-api-key', variable: 'key']]) {
                    println "env.nuget=${env.nuget}"
                    println "env.key=${env.key}"
                    // bat "\"${env.nuget}\" setApiKey ${env.key} -Source http://localhost:32769/repository/nuget-hosted"
                    bat "\"${env.nuget}\" pack Package.nuspec"
                    bat "\"${env.nuget}\" push Package.1.0.0.nupkg ${env.key} -Source http://localhost:32769/repository/nuget-hosted"
                }
            }
        }
    }
}
