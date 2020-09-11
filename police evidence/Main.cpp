#include <iostream>
#include "UserExperience.h"

int main()
{
  std::cout << "App started.\n";
    UI user_experience;
    while (true) {
        user_experience.processCommand();
    }
    return 0;
}