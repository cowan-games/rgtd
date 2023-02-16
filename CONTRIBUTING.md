# Contributing Guidelines

## Development Environment

### Unity

Download and install Unity version `2022.2.6f1`.

### Git

Follow GitHub's guide for [installing git](https://github.com/git-guides/install-git). While you're at it, you can read GitHub's guide to git [here](https://github.com/git-guides) and learn about the commands using the top navigation.

### Code Editor

You can use whatever you like. When installing Unity, you can opt to install Visual Studio and use that. Another popular option is Visual Studio Code.

## Cloning the Repository

> Once the repository is cloned, you can open the repository using the Unity Hub.

1. Using your terminal, navigate to a directory on your computer where you would like to store the repository
2. Clone the repository by running `git clone https://github.com/cowan-games/rgtd.git`

## How to Contribute

> Before attempting to contribute, make sure you have your [development environment](#development-environment) set up properly. After your development environment is set up, make sure you have [cloned the repository](#cloning-the-repository).

1. Select a task from Linear to accomplish (if no task exists, create one)
2. Assign yourself to the task and move the task status to "In Progress"
3. Copy the git branch name for the issue
4. Locally on your computer, make sure the repo is on the `main` branch with the latest changes (run `git fetch` and then `git pull`)
5. Create a new branch and switch to that branch using the git branch name you copied (`git checkout -b BRANCH_NAME`)
6. Push that branch to the remote repository (`git push -u origin BRANCH_NAME`)
7. Complete the task you selected, making any code or asset changes needed
8. Add the changes you added to git (`git add .`)
9. Commit the changes you added with a short message describing the changes (`git commit -m "message"`)
10. Push your changes to the remote repository (`git push`)
11. On github.com, make a pull request from the branch you created into the `main` branch
12. Wait for reviews and make the necessary changes
13. Once approved, either you or a project maintainer may merge the pull request
