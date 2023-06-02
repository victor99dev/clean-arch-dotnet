#!/bin/bash

add_migration() {
    cd src || exit
    dotnet ef migrations add "$1" --project Infra.Data -s WebUI -c ApplicationDbContext
    cd ..
}

update_database() {
    cd src || exit
    dotnet ef database update --project Infra.Data -s WebUI -c ApplicationDbContext
    cd ..
}

remove_migration() {
    cd src || exit
    dotnet ef migrations remove --project Infra.Data -s WebUI -c ApplicationDbContext
    cd ..
}

echo "Select an action:"
echo "1 - Add Migration"
echo "2 - Update Database"
echo "3 - Remove Migration"
read -p "Enter the corresponding number for the desired action: " action

if [[ $action == 1 ]]; then
    read -p "Enter the migration name: " migration_name

    add_migration "$migration_name"
elif [[ $action == 2 ]]; then
    read -p "Do you want to update the database? (y/n): " answer

    if [[ $answer == "y" ]]; then
        update_database
    fi
elif [[ $action == 3 ]]; then
    read -p "Are you sure you want to remove the last migration? (y/n): " answer

    if [[ $answer == "y" ]]; then
        remove_migration
    fi
else
    echo "Invalid action."
fi
