#!/bin/bash
read -p 'new namespace: ' ns

# Replace the namespace in the files
grep -rli 'Boilerplate.WebApi' * | xargs -i@ sed -i 's/Boilerplate.WebApi/'$ns'/g' @

# rename the boilerplate folders and proj files
mv 'Boilerplate.WebApi' $ns
mv $ns'/Boilerplate.WebApi.csproj' $ns/$ns'.csproj'
mv 'Boilerplate.WebApi.Tests/' $ns'.Tests'
mv $ns'.Tests/Boilerplate.WebApi.Tests.csproj' $ns'.Tests'/$ns'.Tests.csproj'
mv 'Boilerplate.WebApi.sln' $ns.sln

# cleanup template repo settings
rm -rf .git/
rm .gitattributes
rm .gitignore

# remove this script
rm -- "$0"