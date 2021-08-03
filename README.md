# GeoTool Project

### Windows Forms Application

## Table of contents
1. [Description](#description)
2. [Technology](#technology)
2. [Installation](#installation)
3. [Details](#details)

## Description

GeoTool application is a tool for structural geology analysis. It allows user to create a variety of popular, geological graphs like rose graph, stereonet and contour graph.

Built-in and light database allows user to add his geo-measurements (coordinates, dip and strike, age and type of a structure). After the completion of measurements, user has the possibility to export data as CSV file.

## Technology

GeoTool application uses:
- Windows Forms framework
- SQLite database management system

## Installation

In order to install and run the application:
1. Clone repository on your computer
2. Find and execute GeoTool.exe file

    GeoTool > GeoTool > bin > Debug > GeoTool.exe


## Details

To create contour graph I used tips from https://www.originlab.com/doc/Origin-Help/Create-Contour-Graph

To smooth polygons in contour graph I applied Chaikin's Algorithm

Finally, to colour polygons I used Efficient Polygon Fill Algorithm by Finley D.R. described in: https://alienryderflex.com/polygon_fill/
