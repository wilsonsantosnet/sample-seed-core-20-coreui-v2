import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './common/services/auth.guard';

const APP_ROUTES_DEFAULT: Routes = [

    {
        path: '', component: MainComponent, data : { title : "Main" }, children: [

            { path: 'samplestandart',  canActivate: [AuthGuard], loadChildren: './main/samplestandart/samplestandart.module#SampleStandartModule' },

            { path: 'sample',  canActivate: [AuthGuard], loadChildren: './main/sample/sample.module#SampleModule' },

            { path: 'sampledetail',  canActivate: [AuthGuard], loadChildren: './main/sampledetail/sampledetail.module#SampleDetailModule' },

            { path: 'sampletype',  canActivate: [AuthGuard], loadChildren: './main/sampletype/sampletype.module#SampleTypeModule' },

            { path: 'product',  canActivate: [AuthGuard], loadChildren: './main/product/product.module#ProductModule' },

            { path: 'sampleproduct',  canActivate: [AuthGuard], loadChildren: './main/sampleproduct/sampleproduct.module#SampleProductModule' },

            { path: 'sampledash',  canActivate: [AuthGuard], loadChildren: './main/sampledash/sampledash.module#SampleDashModule' }

            ]
    },

    { path: 'samplestandart/print/:id', canActivate: [AuthGuard], loadChildren: './main/samplestandart/samplestandart-print/samplestandart-print.module#SampleStandartPrintModule' },

    { path: 'sample/print/:id', canActivate: [AuthGuard], loadChildren: './main/sample/sample-print/sample-print.module#SamplePrintModule' },

    { path: 'sampledetail/print/:id', canActivate: [AuthGuard], loadChildren: './main/sampledetail/sampledetail-print/sampledetail-print.module#SampleDetailPrintModule' },

    { path: 'sampletype/print/:id', canActivate: [AuthGuard], loadChildren: './main/sampletype/sampletype-print/sampletype-print.module#SampleTypePrintModule' },

    { path: 'product/print/:id', canActivate: [AuthGuard], loadChildren: './main/product/product-print/product-print.module#ProductPrintModule' },

    { path: 'sampleproduct/print/:id', canActivate: [AuthGuard], loadChildren: './main/sampleproduct/sampleproduct-print/sampleproduct-print.module#SampleProductPrintModule' },


]


export const RoutingDefault: ModuleWithProviders = RouterModule.forRoot(APP_ROUTES_DEFAULT);


