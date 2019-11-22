pipeline {
    agent any
    stages {
        stage('Test') {
            steps {
                powershell 'docker-compose up --build --abort-on-container-exit'
            }
            post {
                cleanup {
                    powershell "docker-compose down"
                }
            }
        }
    }
}