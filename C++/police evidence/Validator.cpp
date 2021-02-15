#include "Validator.h"

bool Validator::validate_image(const Image& image_to_validate)
{
	if (image_to_validate.get_id_image() == "")
		return false;
	if (image_to_validate.get_measurement_image() == "")
		return false;
	if (image_to_validate.get_clarity_level_image() == "")
		return false;
	if (image_to_validate.get_quantity() == 0)
		return false;
	if (image_to_validate.get_name_image() == "")
		return false;
	return true;
}
