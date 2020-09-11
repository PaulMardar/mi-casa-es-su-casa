#pragma once
#include <stdexcept>
#include <iostream>
#include <vector>
#include <fstream>
#include "Repo.h"


class FileRepo : public Repo
{
protected:
  std::string filename;

  virtual std::vector<Image> load_from_file() = 0;
  virtual void save_to_file(const std::vector<Image>& images) = 0;

public:
    std::string get_filename() {
      return filename;
    }

    FileRepo(const std::string& file_name) : filename{file_name} { }
    void set_file_name(const std::string& file_name) {
      filename = file_name;
    }

    Image get_image_by_id_repo(const std::string& id) override {
      auto images = load_from_file();
      return _get_image_by_id_repo(images, id);
    }

    bool addImage_to_data_base(const Image& image_to_add) {
      auto images = load_from_file();
      if (!_addImage_to_data_base(images, image_to_add))
        return false;

      save_to_file(images);
      return true;
    }

    bool updateImage_data_base(const std::string& id_image,
        const std::string& measurment_image,
        const std::string& clarity_level_image,
        const int& quantity, const std::string& name) {
        auto images = load_from_file();
          if (!_updateImage_data_base(images, id_image, measurment_image, clarity_level_image, quantity, name))
            return false;
          save_to_file(images);
          return true;
        }

    bool id_exists_in_data_base(const std::string& id_image) {
      auto images = load_from_file();
      return _id_exists_in_data_base(images, id_image);
    }

    bool deleteimage_from_data_base(const std::string& id_image) {
      auto images = load_from_file();
      if (!_deleteimage_from_data_base(images, id_image))
        return false;

      save_to_file(images);
      return true;
    }

    std::vector<Image> getImages_all_repo() {
      auto images = load_from_file();
      return images;
    }
};
