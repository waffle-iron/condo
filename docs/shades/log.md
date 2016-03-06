---
layout: docs
title: log
group: shades
---

@{/*

log
    Logs a message to the console or pipeline.

info=''
    The informational message to log.

warn=''
    The warning message to log.

error=''
    The error message to log.

verbose=''
    The verbose message to log.

*/}

use namespace = 'System'

default verbose = ''
default info = ''
default warn = ''
default error = ''
default log_name = ''
default log_value = ''
default log_line = ''
default log_header = ''
default log_quiet = '${ false }'
default log_secure = '${ false }'

@{
    if (!string.IsNullOrEmpty(log_header))
    {
        Build.Log.Info(log_header.ToUpper());
    }

    if (!string.IsNullOrEmpty(log_name) && log_value != null && !string.IsNullOrEmpty(log_value.ToString()))
    {
        Build.Log.Argument(log_name, log_value, log_secure);
    }

    if (!string.IsNullOrEmpty(info))
    {
        Build.Log.Info(info, log_secure);
    }

    if (!string.IsNullOrEmpty(warn))
    {
        Build.Log.Warn(warn, log_secure);
    }

    if (!string.IsNullOrEmpty(error))
    {
        Build.Log.Error(error, log_secure);
    }

    if (!string.IsNullOrEmpty(verbose))
    {
        Build.Log.Verbose(verbose, log_secure);
    }

    if (!string.IsNullOrEmpty(log_line))
    {
        Build.Log.Verbose(string.Empty.PadLeft(105, log_line[0]));
    }
}