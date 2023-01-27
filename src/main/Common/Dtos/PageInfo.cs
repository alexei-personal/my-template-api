﻿using Common.Interfaces;

namespace Common.Dtos;

/// <summary>
/// basic pagination input info
/// </summary>
public sealed record PageInfo : IPageInfo
{
    /// <summary>
    /// 0-indexed page index
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// page item count
    /// </summary>
    public int PageSize { get; set; }
}