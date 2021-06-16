import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FootComponent } from './components/foot/foot.component';
import { HeadingComponent } from './components/heading/heading.component';
import { PanoramaHeaderComponent } from './components/panorama-header/panorama-header.component';
import { ProgressbarComponent } from './components/progressbar/progressbar.component';
import { HomeComponent } from './home/home.component';
import { LayoutRoutingModule } from './layout-routing.module';



@NgModule({
  declarations: [
    HomeComponent,
    FootComponent,
    HeadingComponent,
    ProgressbarComponent,
    PanoramaHeaderComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    FormsModule
  ]
})
export class LayoutModule { }
