#include <algorithm>
#include <iostream>
#include "UserExperience.h"


void UI::processCommand() {
    std::string buffer;
    std::getline(std::cin, buffer);
    std::stringstream argsStream{ buffer };

    std::string command;
    argsStream >> command;

    try {
        if (command == "exit")
            exit(0);
        else if (command == "mode")
            this->mode(argsStream);
        else if (command == "add")
            this->add(argsStream);
        else if (command == "update")
            this->update(argsStream);
        else if (command == "delete")
            this->remove(argsStream);
        else if (command == "list")
            this->list(argsStream); // modify to works with 2 args 
        else if (command == "next")
            this->next(argsStream);
        // todo next
        else if (command == "save")
            this->save(argsStream);
        // todo save to mylist 
        else if (command == "mylist")
            this->list_my_saves(argsStream);
        // todo print mylist 
        else if (command == "fileLocation")
            this->set_file(argsStream);
        else if (command == "mylistLocation")
            this->set_file_mylist(argsStream);
        else
            std::cout << "Unknown command.\n";
    }
    catch (Wrong_mode_exception&) {
        std::cout << "Wrong mode.\n";
    }
}


void UI::mode(std::stringstream& args) {
    std::string mode;
    args >> mode;
    service.set_mode(mode);
}

void UI::set_file(std::stringstream& argsuments)
{
    std::string filename_txt;
    std::getline(argsuments, filename_txt);
    trim_string(filename_txt);
    service.set_file(filename_txt);
}

void UI::add(std::stringstream& argsuments) {
    std::string id;
    std::string measurement;
    std::string clarity_level;
    std::string quantity_string;
    std::string name;

    std::getline(argsuments, id, ',');
    std::getline(argsuments, measurement, ',');
    std::getline(argsuments, clarity_level, ',');
    std::getline(argsuments, quantity_string, ',');
    std::getline(argsuments, name);

    trim_string(id);
    trim_string(measurement);
    trim_string(clarity_level);
    trim_string(name);

    if (!service.addimage_service(id, measurement, clarity_level, std::stoi(quantity_string), name))
        std::cout << "Wrong arguments.\n";
}

void UI::update(std::stringstream& arguments) {
    std::string id;
    std::string measurement;
    std::string clarity_level;
    std::string quantity_string;
    std::string name;

    std::getline(arguments, id, ',');
    std::getline(arguments, measurement, ',');
    std::getline(arguments, clarity_level, ',');
    std::getline(arguments, quantity_string, ',');
    std::getline(arguments, name);

    trim_string(id);
    trim_string(measurement);
    trim_string(clarity_level);
    trim_string(name);

    if (!service.updateimage_service(id, measurement, clarity_level, std::stoi(quantity_string), name))
        std::cout << "Wrong arguments.\n";
}

void UI::remove(std::stringstream& args) {
    std::string id;
    args >> id;

    if (!service.deleteimage_service(id))
        std::cout << "Wrong arguments.\n";
}

void UI::list(std::stringstream& args) {
    std::string buffer;
    std::getline(args, buffer);
    trim_string(buffer);
    if (buffer == "") {
        service.require_mode("A");
        auto vector = service.get_all_images();
        for (int i = 0; i<int(vector.size()); ++i)
            std::cout << vector[i] << '\n';

        return;
    }

    std::stringstream newStream{ buffer };

    std::string measurement;
    int quantity;

    newStream >> measurement >> quantity;

    service.require_mode("B");

    auto vector = service.get_all_images();


    for (int i = 0; i < int(vector.size()); ++i)
    {
        //printf("MERGE if \n");
       // std::cout << measurement << " ";
       //std::cout << quantity <<" ";
        if ((vector[i].get_measurement_image() + ',' == measurement) && (vector[i].get_quantity() < quantity))
        {
            std::cout << vector[i] << '\n';
        }
    }
}

void UI::next(std::stringstream&)
{
    auto result = service.next();
    if (result.first)
        std::cout << result.second << '\n';
}

void UI::save(std::stringstream& args)
{
    std::string id;
    args >> id;
    trim_string(id);
    if (!service.save(id))
        std::cout << "Error: Cannot save.\n";
}

void UI::list_my_saves(std::stringstream&)
{
  auto filepath = service.get_mylist_filename();
  auto extension = filepath.substr(filepath.find_last_of(".") + 1);

  if (extension == "html") {
    // std::cout << filepath << "|\n";
    system(("google-chrome-stable " + filepath).c_str()); // <--- CHANGE SYSTEM CALL
  } else if (extension == "csv" || extension == "txt") {
    system(("libreoffice --calc " + filepath).c_str()); // <--- CHANGE SYSTEM CALL
  } else {
    std::cout << "Invalid file type.\n";
  }
}

void UI::set_file_mylist(std::stringstream& args)
{
  std::string filename;
  std::getline(args, filename);
  trim_string(filename);
  service.set_mylist_file(filename);
}
// to do for cvs and html
