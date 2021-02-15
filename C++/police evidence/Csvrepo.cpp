#include "Csvrepo.h"

std::vector<Image> Csvrepo::load_from_file() {
    std::ifstream filename_toRead_txt(filename);
    Image image;
    std::vector<Image> all_images;
    while (filename_toRead_txt >> image)
    {
      all_images.push_back(image);
    }
    
    return all_images;
}

void Csvrepo::save_to_file(const std::vector<Image>& images) {
    std::ofstream filename_toWrite_txt(filename);
    for (auto image : images)
      filename_toWrite_txt << image << "\n";
}