import { NavigationExtras, Router } from '@angular/router';

export function navigateToTab(router: Router, url: string, extras: string = '') {

    if (extras) {
        const navigationExtra: NavigationExtras = {
            queryParams: {
                data: extras
            }
        };
        router.navigate([url], navigationExtra);
    } else {
        router.navigate([url]);
    }

}
