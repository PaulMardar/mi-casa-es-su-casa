#pragma once
#include <vector>
#include <fstream>
#include "Domain.h"

class Repo
{
protected:
    Image _get_image_by_id_repo(std::vector<Image>& images, const std::string& id);

    bool _addImage_to_data_base(std::vector<Image>& images, const Image& image_to_add);

    bool _updateImage_data_base(std::vector<Image>& images, const std::string& id_image,
        const std::string& measurment_image,
        const std::string& clarity_level_image,
        const int& quantity, const std::string& name);
        
    bool _id_exists_in_data_base(std::vector<Image>& images, const std::string& id_image);
    bool _deleteimage_from_data_base(std::vector<Image>& images, const std::string& id_image);

public:
    virtual ~Repo() = default;
    virtual std::vector<Image> getImages_all_repo() = 0;
    virtual Image get_image_by_id_repo(const std::string& id) = 0;

    virtual bool addImage_to_data_base(const Image& image_to_add) = 0;

    virtual bool updateImage_data_base(const std::string& id_image,
        const std::string& measurment_image,
        const std::string& clarity_level_image,
        const int& quantity, const std::string& name) = 0;
        
    virtual bool id_exists_in_data_base(const std::string& id_image) = 0;
    virtual bool deleteimage_from_data_base(const std::string& id_image) = 0;
};
