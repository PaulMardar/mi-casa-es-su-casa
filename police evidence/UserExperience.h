#pragma once
#pragma once
#include <iostream>
#include <sstream>
#include "Service.h"

class UI {
    Service service;

public:
    UI() {}
    void processCommand();

    void mode(std::stringstream& args);
    void set_file(std::stringstream& argsuments);

    // mode A functions 
    void add(std::stringstream& args);
    void update(std::stringstream& args);
    void remove(std::stringstream& args);
    void list(std::stringstream& args);

    // mode B functions
    void next(std::stringstream& args);
    void save(std::stringstream& args);
    void list_my_saves(std::stringstream& args);

    void set_file_mylist(std::stringstream& args);

    // void see_all_samples_with_given_properties(std::stringstream& args);
};