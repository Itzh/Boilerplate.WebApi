#!/bin/bash
read -p 'new namespace: ' ns

# Replace the namespace in the files
grep -rli 'Boilerplate.WebApi' * | xargs -i@ sed -i 's/Boilerplate.WebApi/'$ns'/g' @

# rename the boilerplate folders
mv 'Boilerplate.WebApi' $ns
mv 'Boilerplate.WebApi.Tests/' $ns'.Tests'

# remove this script
rm -- "$0"
