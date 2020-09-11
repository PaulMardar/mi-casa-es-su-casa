#include <utility>
#include "Service.h"
#include "Validator.h"
#include "Csvrepo.h"
#include "Htmlrepo.h"

void Service::require_mode(const std::string& check_mode) {
    if (this->mode != check_mode)
        throw Wrong_mode_exception{};
}

void Service::set_file(std::string filename_txt)
{
    database.set_file_name(filename_txt);
}

const std::string& Service::get_mode() {
    return this->mode;
}

void Service::set_mode(const std::string& mode_to_set)
{
    this->mode = mode_to_set;
}

std::string Service::get_mylist_filename() {
  return watchlist->get_filename();
}

bool Service::addimage_service(const std::string& id_image,
    const std::string& measurment_image,
    const std::string& clarity_level_image,
    const int& quantity,
    const std::string& name)
{
    require_mode("A");
    return database.addImage_to_data_base(Image{ id_image,
        measurment_image, clarity_level_image, quantity, name });
}

bool Service::updateimage_service(const std::string& id_image,
    const std::string& measurment_image,
    const std::string& clarity_level_image,
    const int& quantity,
    const std::string& name)
{
    require_mode("A");
    return database.updateImage_data_base(id_image,
        measurment_image, clarity_level_image, quantity, name);
}

bool Service::deleteimage_service(const std::string& id_image)
{
    require_mode("A");
    return database.deleteimage_from_data_base(id_image);
}

std::pair<bool, Image> Service::next()
{
    require_mode("B");

    auto data = database.getImages_all_repo();
    if (data.size() == 0)
        return { false, {} };
    ++currentIndex;

    if (currentIndex == int(data.size()))
        currentIndex = 0;

    return { true, data[currentIndex] };
}// to change 

bool Service::save(const std::string& id_image)
{
    require_mode("B");
    if (!database.id_exists_in_data_base(id_image))
        return false;

    auto image = database.get_image_by_id_repo(id_image);
    return watchlist->addImage_to_data_base(image);
}// to change 

std::vector<Image> Service::get_watchlist()
{
    require_mode("B");
    return watchlist->getImages_all_repo();
}// to change 

std::vector<Image> Service::get_all_images()
{
    return database.getImages_all_repo();
}// to change 

void Service::set_mylist_file(const std::string& filename) {
  auto extension = filename.substr(filename.find_last_of(".") + 1);

  if (extension == "html")
    watchlist.reset(new Htmlrepo{filename});
  else if (extension == "csv" || extension == "txt")
    watchlist.reset(new Csvrepo{filename});
  else
    throw Invalid_extension_exception{};
}