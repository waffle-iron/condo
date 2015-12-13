---
layout: docs
title: dotnet-clean
group: shades
---

Cleans a .NET 5 project referenced the a `project.json` file.
## Contents

* Will be replaced with the table of contents
{:toc}

## Supported Operating Systems

{% icon fa-apple fa-3x %} {% icon fa-windows fa-3x %} {% icon fa-linux fa-3x %}

## Arguments

The `dotnet_clean` shade accepts the following arguments:

<div class="table-responsive">
    <table class="table table-bordered table-striped">
    <thead>
        <tr>
            <th style="width:100px;">Name</th>
            <th style="width:50px;">Type</th>
            <th style="width:50px;">Default</th>
            <th style="width:25px;">Required</th>
            <th>Description</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>dotnet_clean_project</td>
            <td>string</td>
            <td></td>
            <td>No</td>
            <td>Path to the `project.json` file to clean.</td>
        </tr>
        <tr>
            <td>dotnet_clean_path</td>
            <td>string</td>
            <td></td>
            <td>No</td>
            <td>Path to the folder containing the `project.json` to clean.</td>
        </tr>
    </tbody>
    </table>
</div>

Note: Either the `dotnet_clean_project` or `dotnet_clean_path` must be specified.

## Global Arguments

The `dotnet_clean` shade does not use any global arguments.

## Examples

### Clean Path

{% highlight sh %}
dotnet_clean dotnet_clean_path='src/myproject'
{% endhighlight %}

### Clean Project

{% highlight sh %}
dotnet_clean dotnet_clean_path='src/myproject/project.json'
{% endhighlight %}