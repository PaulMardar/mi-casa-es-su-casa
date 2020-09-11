#include <stdexcept>
#include <iostream>
#include "Repo.h"

Image Repo::_get_image_by_id_repo(std::vector<Image>& images, const std::string& id)
{
	for (auto i : images)
		if (i.get_id_image() == id)
			return i;
	throw std::out_of_range{ "Repo::get_image_by_id_repo: ID does not exist." };
}// to change

bool Repo::_updateImage_data_base(std::vector<Image>& images, const std::string& id_image, const std::string& measurment_image, const std::string& clarity_level_image, const int& quantity, const std::string& name)
{
	for (auto& i : images)
	{
		if (i.get_id_image() == id_image) {
			i.set_measurment_image(measurment_image);
			i.set_quantity(quantity);
			i.set_name(name);
			i.set_clarity_level_image(clarity_level_image);
			return true;
		}
	}
	return false;
}

bool Repo::_id_exists_in_data_base(std::vector<Image>& images, const std::string& id_image)
{
	for (auto i : images)
		if (i.get_id_image() == id_image)
			return true;
	return false;
}

bool Repo::_deleteimage_from_data_base(std::vector<Image>& images, const std::string& id_image)
{
	for (int i = 0; i<int(images.size()); ++i)
		if (images[i].get_id_image() == id_image)
		{
			images.erase(images.begin() + i);
			return true;
		}
	return false;
}


bool Repo::_addImage_to_data_base(std::vector<Image>& images, const Image& image_to_add) {
    for (auto i : images)
        if (i.get_id_image() == image_to_add.get_id_image())
            return false;
    images.push_back(image_to_add);
    return true;
}