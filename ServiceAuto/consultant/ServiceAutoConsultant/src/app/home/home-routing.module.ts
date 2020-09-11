import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomePage} from './home.page';

const routes: Routes = [
    {
        path: '',
        component: HomePage,
        children: [
            {
                path: 'get-request',
                loadChildren: () => import('./tabs/get-request/get-request.module').then(m => m.GetRequestPageModule)
            },
            {
                path: 'done',
                loadChildren: () => import('./tabs/done/done.module').then(m => m.DonePageModule)
            },
            {
                path: 'requests',
                loadChildren: () => import('./tabs/requests/requests.module').then(m => m.RequestsPageModule)
            },
            {
                path: 'progress',
                loadChildren: () => import('./tabs/progress/progress.module').then(m => m.ProgressPageModule)
            }
            // {
            //     path: '',
            //     redirectTo: '/home/requests',
            //     pathMatch: 'full'
            // }
        ]
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomePageRoutingModule {
}
