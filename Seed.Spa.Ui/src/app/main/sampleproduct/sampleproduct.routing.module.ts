import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SampleProductComponent } from './sampleproduct.component';
import { SampleProductEditComponent } from './sampleproduct-edit/sampleproduct-edit.component';
import { SampleProductDetailsComponent } from './sampleproduct-details/sampleproduct-details.component';
import { SampleProductCreateComponent } from './sampleproduct-create/sampleproduct-create.component';
import { GlobalService } from '../../global.service';


@NgModule({
    imports: [
        RouterModule.forChild([
            { path: '', data : { title : "SampleProduct" }, component: SampleProductComponent },
            { path: 'edit/:id', data : { title : "SampleProduct" } ,component: SampleProductEditComponent },
            { path: 'details/:id', data : { title : "SampleProduct" }, component: SampleProductDetailsComponent },
            { path: 'create', data : { title : "SampleProduct" }, component: SampleProductCreateComponent }
        ])
    ],
    exports: [
        RouterModule
    ]
})

export class SampleProductRoutingModule {
}